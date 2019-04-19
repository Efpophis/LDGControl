using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LDGControl
{
    class Tuner
    {
        public Tuner(string port, PostMeterDataCallback callback )
        {
            m_sio = new SerialIO(port, 38400, SerialIO.StopBits.One, SerialIO.Parity.None);
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
                MeterMode();

                meterThread = new Thread(MeterTelemetry);                

                meterThread.IsBackground = true;

                m_running = true;

                meterThread.Start();
            }

            return result;
        }

        public void Shutdown()
        {
            m_running = false;

            // set thread un-pause event
            m_thread_suspend.Set();

            meterThread.Join();
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
                result = GetResponse();

            MeterMode();

            return result;
        }
        
        public byte[] MemoryTune()
        {
            byte[] result = null;

            CtlMode();

            if (SendCommand(memTuneCmd) == true)
                result = GetResponse();

            MeterMode();

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
            // set read thread pause event
            m_thread_suspend.Reset();

            m_sio.SetBlocking(true);

            // shut off the meter
            SendCommand(ctlCmd);

            // flush the leftove junk if any
            m_sio.Flush();

            
        }

        private void MeterMode()
        {
            // set the read un-pause event
            m_thread_suspend.Set();

            m_sio.SetBlocking(false);

            // restart meter telemetry
            SendCommand(meterCmd);
        }

        private bool SendCommand( byte[] cmd )
        {
            bool result = false;

            if (m_sio.Write(wakeCmd) == wakeCmd.Length)
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
            byte[] readbuf = new byte[19];
            int bytesRead = 0;

            readbuf.Initialize();

            bytesRead = m_sio.Read(readbuf);

            if ( bytesRead == 1 )
            {
                byte[] ret = { readbuf[0] };
                return ret;
            }
            else if ( bytesRead == -1 )
            {
                return null;
            }
            else
            {
                return readbuf;
            }            
        }

        private bool m_running = false;

        private ManualResetEvent m_thread_suspend = new ManualResetEvent(true);

        protected void MeterTelemetry()
        {
            
            while (m_running)
            {
                UInt16 fwd = 0, refl = 0, wtf = 0, eom = 0;

                // check the paused event
                m_thread_suspend.WaitOne();                            
                
                byte[] blob = new byte[8];
                blob.Initialize();

                int ret = m_sio.Read(blob);

                if ( ret > 0 && ret <= blob.Length)
                {
                    if (ret < blob.Length)
                    {
                        m_sio.ReadFully(blob, ret);
                    }

                    if (BitConverter.IsLittleEndian)
                    {
                        // need to fix the blob first ...
                        for (int i = 0; i < blob.Length; i += 2)
                        {
                            byte tmp = blob[i];
                            blob[i] = blob[i + 1];
                            blob[i + 1] = tmp;
                        }

                        fwd = BitConverter.ToUInt16(blob, 0);

                        refl = BitConverter.ToUInt16(blob, 2);

                        wtf = BitConverter.ToUInt16(blob, 4);

                        eom = BitConverter.ToUInt16(blob, 6);
                    }

                    if (eom == 0x3b3b)
                    {
                        MeterCallback?.Invoke(fwd, refl, wtf);
                        //Console.WriteLine("***PING***");
                    }
                    else
                    {
                        // this should never happen, but if it does, it means we've gotten
                        // out of sync. Keep discarding whatever is there until we get
                        // a good packet again.
                        while ( eom != 0x3b3b )
                        {
                            byte[] data = new byte[2];
                            data.Initialize();

                            int len = m_sio.Read(data);
                            if( len > 0 && len < data.Length )
                            {
                                m_sio.ReadFully(data, len);
                                eom = BitConverter.ToUInt16(data, 0);
                            }
                            else if ( len == -1 )
                            {
                                Console.WriteLine("Re-sync read error");
                            }
                                
                            Thread.Sleep(1);
                        }                       
                    }
                }
                else if (ret == -1)
                {
                    Console.WriteLine("Read Thread error on read.");
                    //m_running = false;
                }
                else
                {
                    Thread.Sleep(1);
                    //Console.WriteLine("***PING***");
                }
            }            
        }

        public delegate void PostMeterDataCallback(UInt16 fwd, UInt16 refl, UInt16 wtf);

        private PostMeterDataCallback MeterCallback = null;

        private SerialIO m_sio;

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
