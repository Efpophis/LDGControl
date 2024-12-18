using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LDGControl
{
    public interface iSIO : IDisposable
    {
        int Write(byte[] data);
        int Read(byte[] data);
        bool Open();

        bool Flush();
        bool SetBlocking(bool blocking);

        int ReadFully(byte[] data, int startidx = 0);

        bool isSerial();
    }

    public class NetIO : IDisposable, iSIO
    {
        public NetIO(string host, int port)
        {
            m_host = host;
            m_port = port;
        }

        public bool isSerial() { return false; }
        public bool Open()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(m_host);
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, m_port);
            m_client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            m_client.Connect(ipEndPoint);

            SetBlocking(true);

            return true;
        }

        public int Write(byte[] data)
        {
            return m_client.Send(data);
        }

        public int Read(byte[] data)
        {
            return m_client.Receive(data);
        }

        public void Dispose()
        {
            m_client.Close();
        }

        public bool Flush()
        {
            // no-op for TCP
            return true;
        }

        public bool SetBlocking(bool blocking)
        {
            // doesn't like non-blocking stuff when nothing is there...
            return m_client.Blocking = blocking;
        }

        public int ReadFully(byte[] data, int startidx=0)
        {
            byte[] chunk = new byte[1];
            int bytesRead = startidx;
            int chunkLen = 0;

            while (bytesRead < data.Length)
            {
                chunkLen = Read(chunk);
                if (chunkLen == chunk.Length)
                {
                    data[bytesRead] = chunk[0];
                    ++bytesRead;
                }
                else if (chunkLen == -1)
                {
                    return -1;
                }
            }
            return bytesRead;
        }

        private string m_host;
        private int m_port;
        private Socket m_client;
    }

    public class SerialIO : IDisposable, iSIO
    {
        #region Enum
        public enum StopBits
        {
            None,
            One,
            Two,
            OnePointFive,
        }

        public enum Parity
        {
            None,
            Odd,
            Even,
            Mark,
            Space,
        }
        #endregion
        #region Fields
        /// <summary>
        /// The baud rate at which the communications device operates.
        /// </summary>
        private readonly int iBaudRate;

        /// <summary>
        /// The number of bits in the bytes to be transmitted and received.
        /// </summary>
        private readonly byte byteSize;

        /// <summary>
        /// The system handle to the serial port connection ('file' handle).
        /// </summary>
        private IntPtr pHandle = IntPtr.Zero;

        /// <summary>
        /// The parity scheme to be used.
        /// </summary>
        private readonly Parity parity;

        /// <summary>
        /// The name of the serial port to connect to.
        /// </summary>
        private readonly string sPortName;

        /// <summary>
        /// The number of bits in the bytes to be transmitted and received.
        /// </summary>
        private readonly StopBits stopBits;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of SerialCom.
        /// </summary>
        /// <param>The name of the serial port to connect to</param>
        /// <param>The baud rate at which the communications device operates</param>
        /// <param>The number of stop bits to be used</param>
        /// <param>The parity scheme to be used</param>
        /// <param>The number of bits in the bytes to be transmitted and received</param>
        public SerialIO(string portName, int baudRate, StopBits stopBits, Parity parity, byte byteSize)
        {
            if (stopBits == StopBits.None)
                throw new ArgumentException("stopBits cannot be StopBits.None", "stopBits");
            if (byteSize < 5 || byteSize > 8)
                throw new ArgumentOutOfRangeException("The number of data bits must be 5 to 8 bits.", "byteSize");
            if (baudRate < 110 || baudRate > 256000)
                throw new ArgumentOutOfRangeException("Invalid baud rate specified.", "baudRate");
            if ((byteSize == 5 && stopBits == StopBits.Two) || (stopBits == StopBits.OnePointFive && byteSize > 5))
                throw new ArgumentException("The use of 5 data bits with 2 stop bits is an invalid combination, " +
                    "as is 6, 7, or 8 data bits with 1.5 stop bits.");

            this.sPortName = @"\\.\";
            this.sPortName += portName;
            this.iBaudRate = baudRate;
            this.byteSize = byteSize;
            this.stopBits = stopBits;
            this.parity = parity;
        }

        /// <summary>
        /// Creates a new instance of SerialCom.
        /// </summary>
        /// <param>The name of the serial port to connect to</param>
        /// <param>The baud rate at which the communications device operates</param>
        /// <param>The number of stop bits to be used</param>
        /// <param>The parity scheme to be used</param>
        public SerialIO(string portName, int baudRate, StopBits stopBits, Parity parity)
          : this(portName, baudRate, stopBits, parity, 8)
        {

        }
        #endregion

        #region Open
        /// <summary>
        /// Opens and initializes the serial connection.
        /// </summary>
        /// <returns>Whether or not the operation succeeded</returns>
        public bool Open()
        {
            pHandle = CreateFile(this.sPortName, FileAccess.ReadWrite, FileShare.None,
                IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            if (pHandle == IntPtr.Zero) return false;

            if (ConfigureSerialPort()) return true;
            else
            {
                Dispose();
                return false;
            }
        }
        #endregion

        #region Write
        /// <summary>
        /// Transmits the specified array of bytes.
        /// </summary>
        /// <param>The bytes to write</param>
        /// <returns>The number of bytes written (-1 if error)</returns>
        public int Write(byte[] data)
        {
            FailIfNotConnected();
            if (data == null) return 0;

            int bytesWritten;
            if (WriteFile(pHandle, data, data.Length, out bytesWritten, 0))
                return bytesWritten;
            return -1;
        }

        /// <summary>
        /// Transmits the specified string.
        /// </summary>
        /// <param>The string to write</param>
        /// <returns>The number of bytes written (-1 if error)</returns>
        public int Write(string data)
        {
            FailIfNotConnected();

            // convert the string to bytes
            byte[] bytes;
            if (data == null)
            {
                bytes = null;
            }
            else
            {
                bytes = Encoding.UTF8.GetBytes(data);
            }

            return Write(bytes);
        }

        /// <summary>
        /// Transmits the specified string and appends the carriage return to the end
        /// if it does not exist.
        /// </summary>
        /// <remarks>
        /// Note that the string must end in '\r\n' before any serial device will interpret the data
        /// sent. For ease of programmability, this method should be used instead of Write() when you
        /// want to automatically execute the specified command string.
        /// </remarks>
        /// <param>The string to write</param>
        /// <returns>The number of bytes written (-1 if error)</returns>
        public int WriteLine(string data)
        {
            if (data != null && !data.EndsWith("\r\n"))
                data += "\r\n";
            return Write(data);
        }
        #endregion

        #region Read
        /// <summary>
        /// Reads any bytes that have been received and writes them to the specified array.
        /// </summary>
        /// <param>The array to write the read data to</param>
        /// <returns>The number of bytes read (-1 if error)</returns>
        public int Read(byte[] data)
        {
            FailIfNotConnected();
            if (data == null) return 0;

            int bytesRead;
            if (ReadFile(pHandle, data, data.Length, out bytesRead, 0))
                return bytesRead;
            return -1;
        }

        public int ReadFully( byte[] data, int startidx = 0)
        {
            byte[] chunk = new byte[1];
            int bytesRead = startidx;
            int chunkLen = 0;

            while ( bytesRead < data.Length )
            {
                chunkLen = Read(chunk);
                if (chunkLen == chunk.Length)
                {
                    data[bytesRead] = chunk[0];
                    ++bytesRead;
                }
                else if ( chunkLen == -1 )
                {
                    return -1;
                }
            }
            return bytesRead;
        }

        public bool SetBlocking( bool block )
        {
            // set the serial connection timeouts
            COMMTIMEOUTS timeouts = new COMMTIMEOUTS();
            //timeouts.ReadIntervalTimeout = block ? 100 : uint.MaxValue;
            timeouts.ReadIntervalTimeout = 100;
            timeouts.ReadTotalTimeoutMultiplier = 0;
            timeouts.ReadTotalTimeoutConstant = (uint)(block ? 0 : 100);
            timeouts.WriteTotalTimeoutMultiplier = 0;
            timeouts.WriteTotalTimeoutConstant = 0;
            if (SetCommTimeouts(pHandle, ref timeouts))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isSerial() { return true; }

        /// <summary>
        /// Reads any data that has been received as a string.
        /// </summary>
        /// <param>The maximum number of bytes to read</param>
        /// <returns>The data received (null if no data)</returns>
        public string ReadString(int maxBytesToRead)
        {
            if (maxBytesToRead < 1) throw new ArgumentOutOfRangeException("maxBytesToRead");

            byte[] bytes = new byte[maxBytesToRead];
            int numBytes = Read(bytes);
            //string data = ASCIIEncoding.ASCII.GetString(bytes, 0, numBytes);
            string data = Encoding.UTF8.GetString(bytes, 0, numBytes);
            return data;
        }
        #endregion

        #region Dispose Utils
        /// <summary>
        /// Disconnects and disposes of the SerialCom instance.
        /// </summary>
        public void Dispose()
        {
            if (pHandle != IntPtr.Zero)
            {
                CloseHandle(pHandle);
                pHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Flushes the serial I/O buffers.
        /// </summary>
        /// <returns>Whether or not the operation succeeded</returns>
        public bool Flush()
        {
            FailIfNotConnected();

            const int PURGE_RXCLEAR = 0x0008; // input buffer
            const int PURGE_TXCLEAR = 0x0004; // output buffer
            return PurgeComm(pHandle, PURGE_RXCLEAR | PURGE_TXCLEAR);
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Configures the serial device based on the connection parameters pased in by the user.
        /// </summary>
        /// <returns>Whether or not the operation succeeded</returns>
        private bool ConfigureSerialPort()
        {
            DCB serialConfig = new DCB();
            if (GetCommState(pHandle, ref serialConfig))
            {
                // setup the DCB struct with the serial settings we need
                serialConfig.BaudRate = (uint)this.iBaudRate;
                serialConfig.ByteSize = this.byteSize;
                serialConfig.fBinary = 1; // must be true
                serialConfig.fDtrControl = 1; // DTR_CONTROL_ENABLE "Enables the DTR line when the device is opened and leaves it on."
                serialConfig.fAbortOnError = 0; // false
                serialConfig.fTXContinueOnXoff = 0; // false

                serialConfig.fParity = 1; // true so that the Parity member is looked at
                switch (this.parity)
                {
                    case Parity.Even:
                        serialConfig.Parity = 2;
                        break;
                    case Parity.Mark:
                        serialConfig.Parity = 3;
                        break;
                    case Parity.Odd:
                        serialConfig.Parity = 1;
                        break;
                    case Parity.Space:
                        serialConfig.Parity = 4;
                        break;
                    case Parity.None:
                    default:
                        serialConfig.Parity = 0;
                        break;
                }
                switch (this.stopBits)
                {
                    case StopBits.One:
                        serialConfig.StopBits = 0;
                        break;
                    case StopBits.OnePointFive:
                        serialConfig.StopBits = 1;
                        break;
                    case StopBits.Two:
                        serialConfig.StopBits = 2;
                        break;
                    case StopBits.None:
                    default:
                        throw new ArgumentException("stopBits cannot be StopBits.None");
                }

                if (SetCommState(pHandle, ref serialConfig))
                {
                    // set the serial connection timeouts
                    COMMTIMEOUTS timeouts = new COMMTIMEOUTS();
                    timeouts.ReadIntervalTimeout = 100;
                    timeouts.ReadTotalTimeoutMultiplier = 0;
                    timeouts.ReadTotalTimeoutConstant = 0;
                    timeouts.WriteTotalTimeoutMultiplier = 0;
                    timeouts.WriteTotalTimeoutConstant = 0;
                    if (SetCommTimeouts(pHandle, ref timeouts))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Helper that throws a InvalidOperationException if we don't have a serial connection.
        /// </summary>
        private void FailIfNotConnected()
        {
            if (pHandle == IntPtr.Zero)
                throw new InvalidOperationException("You must be connected to the serial port before performing this operation.");
        }
        #endregion

        #region Native Helpers
        #region Native structures
        /// <summary>
        /// Contains the time-out parameters for a communications device.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct COMMTIMEOUTS
        {
            public uint ReadIntervalTimeout;
            public uint ReadTotalTimeoutMultiplier;
            public uint ReadTotalTimeoutConstant;
            public uint WriteTotalTimeoutMultiplier;
            public uint WriteTotalTimeoutConstant;
        }

        /// <summary>
        /// Defines the control setting for a serial communications device.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct DCB
        {
            public int DCBlength;
            public uint BaudRate;
            public uint Flags;
            public ushort wReserved;
            public ushort XonLim;
            public ushort XoffLim;
            public byte ByteSize;
            public byte Parity;
            public byte StopBits;
            public sbyte XonChar;
            public sbyte XoffChar;
            public sbyte ErrorChar;
            public sbyte EofChar;
            public sbyte EvtChar;
            public ushort wReserved1;
            public uint fBinary;
            public uint fParity;
            public uint fOutxCtsFlow;
            public uint fOutxDsrFlow;
            public uint fDtrControl;
            public uint fDsrSensitivity;
            public uint fTXContinueOnXoff;
            public uint fOutX;
            public uint fInX;
            public uint fErrorChar;
            public uint fNull;
            public uint fRtsControl;
            public uint fAbortOnError;
        }
        #endregion

        #region Native Methods
        // Used to get a handle to the serial port so that we can read/write to it.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateFile(string fileName,
           [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
           [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
           IntPtr securityAttributes,
           [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
           int flags,
           IntPtr template);

        // Used to close the handle to the serial port.
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        // Used to get the state of the serial port so that we can configure it.
        [DllImport("kernel32.dll")]
        static extern bool GetCommState(IntPtr hFile, ref DCB lpDCB);

        // Used to configure the serial port.
        [DllImport("kernel32.dll")]
        static extern bool SetCommState(IntPtr hFile, [In] ref DCB lpDCB);

        // Used to set the connection timeouts on our serial connection.
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCommTimeouts(IntPtr hFile, ref COMMTIMEOUTS lpCommTimeouts);

        // Used to read bytes from the serial connection.
        [DllImport("kernel32.dll")]
        static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer,
           int nNumberOfBytesToRead, out int lpNumberOfBytesRead, int lpOverlapped);

        // Used to write bytes to the serial connection.
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer,
            int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten, int lpOverlapped);

        // Used to flush the I/O buffers.
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool PurgeComm(IntPtr hFile, int dwFlags);
        #endregion
        #endregion
    }
}
