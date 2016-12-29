using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace RS232
{
    public class ModelRS232
    {
        private ModelKonfiguracji _conf;
        private SerialPort _currentSerial;

            public event SerialDataReceivedEventHandler DataReceived
            {
                add { _currentSerial.DataReceived += value; }
                remove { _currentSerial.DataReceived -= value; }
            }

        public SerialPort CurrentSerial
        {
            get { return _currentSerial; }
        }

        public ModelRS232(ModelKonfiguracji conf)
        {
            _conf = conf;
            SetPortProperties(conf);
        }

        private void SetPortProperties(ModelKonfiguracji conf)
        {
            _currentSerial = new SerialPort();
            _currentSerial.Encoding = Encoding.GetEncoding(28591);
            _currentSerial.PortName = conf.Port;
            _currentSerial.Parity = conf.Parity;
            _currentSerial.StopBits = (StopBits)conf.StopBits;
            _currentSerial.BaudRate = conf.Speed;
            _currentSerial.DataBits = conf.DataBits;
            _currentSerial.NewLine = conf.Terminator;
            _currentSerial.Handshake = conf.FlowControl.Handshake;
            _currentSerial.DtrEnable = conf.FlowControl.DtrEnable;
            _currentSerial.ReadTimeout = 10000;
            _currentSerial.WriteTimeout = 10000;
            _currentSerial.Open();
        }
    }
}
