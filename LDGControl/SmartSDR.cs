using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace LDGControl
{
    public class SmartSDR
    {
        public SmartSDR()
        { 
        }
        ~SmartSDR() { Close();  }

        public void Init(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, port);
            m_client = new Socket( ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            m_client.Connect(ipEndPoint);

            // read the initial stuff we don't care about right now
            var buffer = new byte[1024];
            int bytesRx = m_client.Receive(buffer);
        }

        public void startTune()
        {
            string cmd = "C" + m_seq++.ToString() + "|transmit tune on\r\n";
            m_client.Send(Encoding.ASCII.GetBytes(cmd));
        }

        public void stopTune()
        {
            string cmd = "C" + m_seq++.ToString() + "|transmit tune off\r\n";
            m_client.Send(Encoding.ASCII.GetBytes(cmd));
        }

        public void Close()
        {
            m_client.Close();
        }

        private int m_seq = 1;
        private Socket m_client;
    }
}
