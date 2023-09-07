using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LDGControl
{
    public class SmartSDR
    {
        public SmartSDR()
        { 
        }
        ~SmartSDR() { Close();  }

        private bool Discover()
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint localEndpt = new IPEndPoint(IPAddress.Any, 4992);
            bool result = false;

            udpClient.Client.SetSocketOption( SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true );
            udpClient.Client.Bind(localEndpt);
            udpClient.Client.ReceiveTimeout = 2000;

            try
            {
                byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);

                if (receiveBytes.Length > 7)
                {
                    int headerLen = 7 * sizeof(UInt32);

                    string payload = Encoding.ASCII.GetString(receiveBytes, headerLen, receiveBytes.Length - headerLen);

                    m_discovery = new Dictionary<string, string>();

                    string[] payloadStrings = payload.Split(' ');
                    foreach (string str in payloadStrings)
                    {
                        //MessageBox.Show(str);
                        string[] payloadItem = str.Split('=');
                        if (payloadItem.Length == 2)
                        {
                            m_discovery[payloadItem[0]] = payloadItem[1];
                        }
                        else
                        {
                            m_discovery[payloadItem[0]] = "";
                        }

                    }

                    DialogResult answer = MessageBox.Show("Discovered a " + m_discovery["model"] + " at IP " + m_discovery["ip"] + ":" + m_discovery["port"] + "\r\nConnect?", "Flex Discovery Results", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        result = true;
                    }
                }
                else
                {
                    MessageBox.Show("Discovery got gobbledegook");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No radios found");
            }
            
            return result;
        }

        public void Init()
        {
            if (Discover())
            {
                m_host = m_discovery["ip"];
                m_port = int.Parse(m_discovery["port"]);

                IPHostEntry ipHostInfo = Dns.GetHostEntry(m_host);
                IPAddress iPAddress = ipHostInfo.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, m_port);
                m_client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                m_client.Connect(ipEndPoint);

                // read the initial stuff we don't care about right now
                var buffer = new byte[1024];
                int bytesRx = m_client.Receive(buffer);
            }
        }

        public void startTune()
        {
            if (m_port > 0)
            {
                string cmd = "C" + m_seq++.ToString() + "|transmit tune on\r\n";
                m_client.Send(Encoding.ASCII.GetBytes(cmd));
            }
        }

        public void stopTune()
        {
            if (m_port > 0)
            {
                string cmd = "C" + m_seq++.ToString() + "|transmit tune off\r\n";
                m_client.Send(Encoding.ASCII.GetBytes(cmd));
            }
        }

        public void Close()
        {
            if (m_port > 0)
            {
                m_client.Close(); 
            }
        }

        private int m_seq = 1;
        private string m_host = "";
        private int m_port = 0;
        private Socket m_client;
        private Dictionary<string, string> m_discovery;
    }
}
