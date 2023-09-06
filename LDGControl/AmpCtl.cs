using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGControl
{
    class AmpCtl
    {
        public AmpCtl(string port)
        {
            m_sio = new SerialIO(port, 9600, SerialIO.StopBits.One, SerialIO.Parity.None);

            if (m_sio.Open() == false)
            {
                throw new Exception("Failed to open serial port");
            }

            ampOn();
        }
        
        public AmpCtl(string host, int port)
        {
            m_sio = new NetIO(host, port);

            if ( m_sio.Open() == false)
            {
                throw new Exception("Failed to open TCP connection to " + host + ":" + port);
            }
            ampOn();
        }
        
        public void ampOn()
        {
            m_sio.Write(onCmd);
        }

        public void ampOff()
        {
            m_sio.Write(offCmd);
        }

        private iSIO m_sio;
        private static readonly byte[] onCmd  = new byte[] { 0xff, 0x01, 0x00 };
        private static readonly byte[] offCmd = new byte[] { 0xff, 0x01, 0x01 };
    }
}
