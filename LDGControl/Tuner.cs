using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using LDGControl.Properties;
using System.Diagnostics;


namespace LDGControl
{
    class Tuner
    {
        public Tuner(string port, PostMeterDataCallback callback )
        {
            m_sio = new SerialIO(port, 38400, SerialIO.StopBits.One, SerialIO.Parity.None);
            MeterCallback = callback;
        }

        public Tuner(string host, int port, PostMeterDataCallback callback)
        {
            m_sio = new NetIO(host, port);
            MeterCallback = callback;
        }

        ~Tuner()
        {
            if ( m_running )
            {
                Shutdown();
            }
        }

        public bool Init()
        {
            bool result = false;

            if (m_sio.Open())
            {
                m_sio.SetBlocking( !m_sio.isSerial() );

                if ( Settings.Default.flex_enabled == true ) 
                {
                    // attempt to initiate a flex connectin here
                    m_flex = new SmartSDR();
                    m_flex.Init();
                }

                m_respSem = new Semaphore(1,1);
                m_response = 0;

                MeterMode();

                meterThread = new Thread(ReadThread);                

                meterThread.IsBackground = true;

                m_running = true;

                meterThread.Start();                
            }

            return result;
        }

        public void Shutdown()
        {
            m_running = false;
                        
            meterThread.Join();
            if (m_flex != null) m_flex.Close();
            m_sio.Dispose();
        }

        public byte[] Sync()
        {
            byte[] result = null;

            CtlMode();

            if ( SendCommand(syncCmd) == true )
            {
                result = GetResponse();
            }

            MeterMode();
            
            return result;
        }

        public byte[] Toggle()
        {
            byte[] result = null;

            CtlMode();

            if (SendCommand(toggleAntCmd) == true)
                result = GetResponse();

            MeterMode();

            return result;            
        }

        public byte[] ForceFullTune()
        {
            byte[] result = null;

            CtlMode();

            if (SendCommand(fullTuneCmd) == true)
            {
                if (m_flex != null)
                    m_flex.startTune();

                result = GetResponse();

                if (m_flex != null)
                    m_flex.stopTune();
            }

            MeterMode();

            return result;
        }
        
        public byte[] MemoryTune()
        {
            byte[] result = null;
            Debug.WriteLine("MemoryTune()");
            CtlMode();
            Debug.WriteLine("   ctlMode()");
            if (SendCommand(memTuneCmd) == true)
            {
                Debug.WriteLine("      sent command");
                if (m_flex != null)
                    m_flex.startTune();

                Debug.WriteLine("      waiting response");
                result = GetResponse();
                Debug.WriteLine("      got {0}", result);
                if (m_flex != null)
                    m_flex.stopTune();
            }
            Debug.WriteLine("   MeterMode()");
            MeterMode();

            Debug.WriteLine(" Return {0}", result);
            return result;
        }

        public byte[] Bypass()
        {
            byte[] result = null;

            CtlMode();

            if (SendCommand(bypassCmd) == true)
                result = GetResponse();

            MeterMode();

            return result;
        }

        public byte[] AutoTuneMode()
        {
            byte[] result = null;

            CtlMode();

            if (SendCommand(autoCmd) == true)
                result = GetResponse();

            MeterMode();

            return result;
        }

        public byte[] ManualTuneMode()
        {
            byte[] result = null;

            CtlMode();

            if (SendCommand(manualCmd) == true)
                result = GetResponse();

            MeterMode();

            return result;
        }

        private void CtlMode()
        {
            // shut off the meter
            SendCommand(ctlCmd);

            // we set the thread state AFTER sending the command
            // because the command itself can cause another meter
            // message to be sent back before the tuner actually
            // makes the switch. This lets our thread handle it and
            // avoids wonky errors.

            m_threadState = ThreadState.RESP;
        }

        private void MeterMode()
        {
            // setting METER state before sending the command ensures
            // that the thread is ready to process the meter telemetry
            // that will be sent immediately.
            m_threadState = ThreadState.METER;

            // restart meter telemetry
            SendCommand(meterCmd);
        }

        private bool WakeUp()
        {
            bool result = true;

            for (int i = 0; i < 2; i++)
            {
                if (m_sio.Write(wakeCmd) != wakeCmd.Length)
                {
                    result = false;
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
            return result;
        }

        private bool SendCommand( byte[] cmd )
        {
            bool result = false;

            if (m_sio.Write(wakeCmd) != wakeCmd.Length)
            {
                Thread.Sleep(1);
                if (m_sio.Write(cmd) == cmd.Length)
                {
                    // doc says wait 200ms minimum before next command,
                    // so we enforce that here, with a little extra.
                    Thread.Sleep(250);

                    result = true;
                }
            }
            return result;
        }        

        private byte[] GetResponse()
        {
            byte[] ret = new byte[1];
            bool done = false;

            while (!done)
            {
                m_respSem.WaitOne();
                if ( m_response != 0 )
                {
                    ret[0] = m_response;
                    m_response = 0;
                    done = true;
                }
                m_respSem.Release();
                Thread.Sleep(1);
            }
            return ret;
        }

        private bool m_running = false;

        //private ManualResetEvent m_thread_suspend = new ManualResetEvent(true);

        protected void ReadThread()
        {
            
            byte[] readBuf = new byte[1];
            int idx = 0;
            int eomcnt = 0;
            byte[] meterBlob = new byte[8];
            Debug.WriteLine("Read Thread started ..");

            while (m_running)
            {
                int ret = m_sio.Read(readBuf);

                if ( ret == 1 )
                {
                    byte b = readBuf[0];

                    Debug.WriteLine("0x{0:x}", b);

                    switch(m_threadState)
                    {
                        case ThreadState.RESP:
                            { 
                                if ( b >= 0x30 )
                                {
                                    // sem take
                                    m_respSem.WaitOne();

                                    Debug.WriteLine("published response {0}", b);
                                    m_response = b;
                                    
                                    //sem give
                                    m_respSem.Release();                                    
                                }
                                else
                                {
                                    Debug.WriteLine("WARN: bad response {0:x}", b);
                                    m_respSem.WaitOne();
                                    m_response = (byte)'E';
                                    m_respSem.Release();
                                }
                            }
                            break;

                        case ThreadState.METER:
                            {
                                try
                                {
                                    if (idx < 6)
                                    {
                                        meterBlob[idx++] = b;
                                    }
                                    else if ((int)b == 0x3b)
                                    {                                        
                                        ++eomcnt;
                                        if (eomcnt == 2)
                                        {
                                            // publish blob
                                            if (idx == 6)
                                            {
                                                Debug.WriteLine("updated meter");
                                                publishMeterBlob(meterBlob);                                            
                                            }

                                            idx = 0;
                                            eomcnt = 0;                                            
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine("ERROR: byte read == {0:x}, Protocl error, no eom found!!", b);
                                        idx = 0;
                                        eomcnt = 0;
                                        m_threadState = ThreadState.ERROR;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Debug.WriteLine("Exception caught: {0}", e.Message);
                                    Debug.WriteLine("idx == {0}", idx);
                                    Debug.WriteLine("eomcnt == {0}", eomcnt);
                                    Debug.WriteLine("meterblob == {0}", meterBlob);
                                    Debug.WriteLine("byte read == {0:x}", b);
                                    idx = 0;
                                    eomcnt = 0;
                                    m_threadState = ThreadState.ERROR;
                                }                                
                            }
                            break;

                            case ThreadState.ERROR:
                            {
                                if ( (int)b == 0x3b )
                                {
                                    ++eomcnt;
                                }
                                if ( eomcnt >= 2 )
                                {
                                    m_threadState = ThreadState.METER;
                                    eomcnt = 0;
                                    idx = 0;
                                    Debug.WriteLine("Recovered from error state");
                                }
                            }
                            break;
                    }
                }
                else
                {
                    //Debug.WriteLine("read failed??");
                    Thread.Sleep(100);
                }
            }
        }

        protected void publishMeterBlob(byte[] blob)
        {
            if (BitConverter.IsLittleEndian)
            {
                // need to fix the blob first ...
                // this reverses each unsigned short
                // in the data payload, and is specific
                // to this tuner. Don't try this on your own
                // data unless you know what you're doing.
                for (int i = 0; i < blob.Length; i += 2)
                {
                    byte tmp = blob[i];
                    blob[i] = blob[i + 1];
                    blob[i + 1] = tmp;
                }
            }

            UInt16 fwd = BitConverter.ToUInt16(blob, 0);

            UInt16 refl = BitConverter.ToUInt16(blob, 2);

            UInt16 wtf = BitConverter.ToUInt16(blob, 4);

            MeterCallback?.Invoke(fwd, refl, wtf);
        }

        

        public delegate void PostMeterDataCallback(UInt16 fwd, UInt16 refl, UInt16 wtf);

        private PostMeterDataCallback MeterCallback = null;

        private iSIO m_sio;
        private SmartSDR m_flex = null;

        //private string m_flexHost;
        //private int m_flexPort;
        private byte m_response;

        private static Semaphore m_respSem;

        private enum ThreadState
        {
            RESP,
            METER,
            ERROR
        };

        private static ThreadState m_threadState = ThreadState.RESP;
        

        private static readonly byte[] toggleAntCmd = { (byte)'A'};
        private static readonly byte[] memTuneCmd = { (byte)'T'};
        private static readonly byte[] fullTuneCmd = { (byte)'F' };
        private static readonly byte[] bypassCmd = { (byte)'P' };
        private static readonly byte[] autoCmd = { (byte)'C' };
        private static readonly byte[] manualCmd = { (byte)'M' };
        private static readonly byte[] syncCmd = { (byte)'Z' };
        private static readonly byte[] meterCmd = { (byte)'S' };
        private static readonly byte[] ctlCmd = { (byte)'X' };
        private static readonly byte[] wakeCmd = { (byte)' ' };

        private Thread meterThread;
    }
}
