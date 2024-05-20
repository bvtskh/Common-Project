using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonProject.Business
{
    public class CommPort
    {
        SerialPort _serialPort;
        Thread _readThread;
        volatile bool _keepReading;

        //begin Singleton pattern
        static readonly CommPort instance = new CommPort();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static CommPort()
        {
        }

        CommPort()
        {
            _serialPort = new SerialPort();
            _readThread = null;
            _keepReading = false;
        }

        public static CommPort Instance
        {
            get
            {
                return instance;
            }
        }
        //end Singleton pattern

        //begin Observer pattern
        public delegate void EventHandler(string param);
        public EventHandler StatusChanged;
        public EventHandler DataReceived;
        //end Observer pattern

        private void StartReading()
        {
            if (!_keepReading)
            {
                _keepReading = true;
                _readThread = new Thread(ReadPort);
                _readThread.Start();
            }
        }

        private void StopReading()
        {
            if (_keepReading)
            {
                _keepReading = false;
                _readThread.Join(); //block until exits
                _readThread = null;
            }
        }

        /// <summary> Get the data and pass it on. </summary>
        private void ReadPort()
        {
            while (_keepReading)
            {
                if (_serialPort.IsOpen)
                {
                    byte[] readBuffer = new byte[_serialPort.ReadBufferSize + 1];
                    try
                    {
                        // If there are bytes available on the serial port,
                        // Read returns up to "count" bytes, but will not block (wait)
                        // for the remaining bytes. If there are no bytes available
                        // on the serial port, Read will block until at least one byte
                        // is available on the port, up until the ReadTimeout milliseconds
                        // have elapsed, at which time a TimeoutException will be thrown.
                        int count = _serialPort.Read(readBuffer, 0, _serialPort.ReadBufferSize);
                        String SerialIn = System.Text.Encoding.ASCII.GetString(readBuffer, 0, count);
                        DataReceived(SerialIn);
                    }
                    catch (TimeoutException) { }
                }
                else
                {
                    TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
                    Thread.Sleep(waitTime);
                }
            }
        }

        /// <summary> Open the serial port with current settings. </summary>
        public void Open(string portName)
        {
            Close();
            try
            {
                _serialPort.PortName = portName;
                _serialPort.Open();
                StatusChanged(String.Format("{0} OK", portName));
            }
            catch (IOException)
            {
                StatusChanged(String.Format("{0} does not exist", portName));
            }
            catch (UnauthorizedAccessException)
            {
                StatusChanged(String.Format("{0} already in use", portName));
            }
            catch (Exception ex)
            {
                StatusChanged(String.Format("{0}", ex.ToString()));
            }
        }

        /// <summary> Close the serial port. </summary>
        public void Close()
        {
            _serialPort.Close();
            StatusChanged("connection closed");
        }

        /// <summary> Get the status of the serial port. </summary>
        public bool IsOpen
        {
            get
            {
                return _serialPort.IsOpen;
            }
        }

        /// <summary> Get a list of the available ports. Already opened ports
        /// are not returend. </summary>
        public string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>Send data to the serial port after appending line ending. </summary>
        /// <param name="data">An string containing the data to send. </param>
        public void Send(string data)
        {
            if (IsOpen)
            {
                _serialPort.Write(data);
            }
        }
    }
}
