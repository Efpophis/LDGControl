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

            // shut off the meter
            SendCommand(ctlCmd);

            // flush the leftove junk if any
            m_sio.Flush();

            m_sio.SetBlocking(true);
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
                System.Threading.Thread.Sleep(1);
                if (m_sio.Write(cmd) == cmd.Length)
                {
                    // doc says wait 200ms minimum before next command,
                    // so we enforce that here.
                    System.Threading.Thread.Sleep(200);

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
                Int16 fwd = 0, refl = 0, wtf = 0, eom = 0;

                // check the paused event
                m_thread_suspend.WaitOne();

                // read fwd
                byte[] chunk = new byte[1];
                byte[] data = new byte[2];

                int ret = m_sio.Read(chunk);

                if (ret == chunk.Length)
                {
                    // we got one! Read the rest...
                    data[0] = chunk[0];

                    m_sio.ReadFully(chunk);

                    data[1] = chunk[0];

                    fwd = BitConverter.ToInt16(data, 0);

                    m_sio.ReadFully(data);

                    refl = BitConverter.ToInt16(data, 0);

                    m_sio.ReadFully(data);

                    wtf = BitConverter.ToInt16(data, 0);

                    m_sio.ReadFully(data);

                    eom = BitConverter.ToInt16(data, 0);

                    if (eom == 0x3b3b)
                    {
                        fwd = System.Net.IPAddress.NetworkToHostOrder(fwd);
                        refl = System.Net.IPAddress.NetworkToHostOrder(refl);
                        wtf = System.Net.IPAddress.NetworkToHostOrder(wtf);

                        MeterCallback?.Invoke(fwd, refl, wtf);
                    }
                }
                else if (ret == -1)
                {
                    System.Console.WriteLine("Read Thread error on read. Stopping thread.");
                    m_running = false;
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                }
            }            
        }

        public delegate void PostMeterDataCallback(Int16 fwd, Int16 refl, Int16 wtf);

        private PostMeterDataCallback MeterCallback = null;

        private SerialIO m_sio;

        private static readonly byte[] toggleAntCmd = { (byte)'A'};
        private static readonly byte[] memTuneCmd = { (byte)'M'};
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
