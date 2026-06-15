using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGControl
{
    public enum AmpStatus
    {
        ON = 0,
        OFF = 1,
        FAIL = 2
    }

    class AmpCtl
    {
        private AmpCtl() 
        {
            m_status = AmpStatus.FAIL;
        }

        public AmpCtl(string port) : this()
        {
            m_sio = new SerialIO(port, 9600, SerialIO.StopBits.One, SerialIO.Parity.None);

            if (m_sio.Open() == false)
            {
                throw new Exception("Failed to open serial port");
            }

            m_status = queryStatus();
        }
        
        public AmpCtl(string host, int port) : this()
        {
            m_sio = new NetIO(host, port);

            if ( m_sio.Open() == false)
            {
                throw new Exception("Failed to open TCP connection to " + host + ":" + port);
            }

            m_status = queryStatus(); // ampOn();
        }
        
        public void ampOn()
        {
            m_sio.Write(onCmd);
            m_status = queryStatus();
        }

        public void ampOff()
        {
            m_sio.Write(offCmd);
            m_status = queryStatus();
        }

        public AmpStatus ampStatus()
        {
            return m_status;
        }

        private AmpStatus queryStatus()
        {
            byte[] ret = new byte[3];
            AmpStatus status = AmpStatus.FAIL;

            try
            {
                m_sio.Write(statusCmd);
                m_sio.ReadFully(ret);
                if (ret[0] == 0xff && ret[1] == 0x01)
                    status = (AmpStatus) ret[2];
            }
            catch (Exception)
            {
                status = AmpStatus.FAIL;
            }

            return status;
        }

        private AmpStatus m_status = AmpStatus.FAIL;
        private iSIO m_sio;
        private static readonly byte[] onCmd  = new byte[] { 0xff, 0x01, 0x00 };
        private static readonly byte[] offCmd = new byte[] { 0xff, 0x01, 0x01 };
        private static readonly byte[] statusCmd = new byte[] { 0xff, 0x01, 0x03 };
    }
}
