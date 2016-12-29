using Be.Windows.Forms;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace RS232
{
    public partial class Form1 : Form
    {
        private ModelKonfiguracji _modelKonfiguracji = null;
        private ModelRS232 _modelRS232 = null;
        private const string _pingMessage = "P@ING";
        private const string _pongMessage = "P@ONG";
        private Stopwatch _pingPongStopwatch = new Stopwatch();
        private System.Timers.Timer _pingPongElapsedTimer = new System.Timers.Timer();
        private MemoryStream _receiveMS;
        private MemoryStream _sendStream;
        public Form1()
        {
            InitializeComponent();
            ChangeGuiState(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            prompt.Text += "-- Oczekiwanie na konfigurację --";
            _pingPongElapsedTimer.Interval = 2000;
            _pingPongElapsedTimer.Elapsed += HandleElapsedPongTimer;

            _sendStream = new MemoryStream();
            hexBox1.ByteProvider = new DynamicFileByteProvider(_sendStream);
            _receiveMS = new MemoryStream();
            hexBox2.ByteProvider = new DynamicFileByteProvider(_receiveMS);
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var konfiguracja = new Konfiguracja();
            var obecnaKonfiguracja = _modelKonfiguracji;
            konfiguracja.ShowDialog();
            if (konfiguracja.ModelKonfiguracji == null)
                return;
            _modelKonfiguracji = konfiguracja.ModelKonfiguracji;
            this.Text = "RS232 - " + _modelKonfiguracji.Port;
            if(_modelRS232 != null)
            {
                _modelRS232.CurrentSerial.Close();
                _modelRS232.CurrentSerial.Dispose();
                GC.SuppressFinalize(this);
                Thread.Sleep(500);
            }

            _modelRS232 = new ModelRS232(_modelKonfiguracji);

            TruncateStream(hexBox1, _sendStream);
            TruncateStream(hexBox2, _receiveMS);

            ChangeGuiState(true);
            if (_modelKonfiguracji != null)
            {
                prompt.Text += "\n-- Konfigurację zatwierdzono --";
            }
            _modelRS232.DataReceived += HandleDataReceived;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _modelRS232.CurrentSerial.WriteLine(nadawanie.Text);
            prompt.Text += "\nWysłano komunikat";
            nadawanie.Text = String.Empty;
        }

        private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string received;
            try
            {
                SerialPort sp = (SerialPort)sender;
                received = sp.ReadLine();
            }
            catch(Exception ex)
            {
                return;
            }

            if (received.Equals(_pongMessage))
            {
                _pingPongStopwatch.Stop();
                odbior.Text += "\n(Odebrano): PAKIET PONG; Round trip time: " + _pingPongStopwatch.ElapsedMilliseconds.ToString() + " ms";
                _pingPongStopwatch.Reset();
                _pingPongElapsedTimer.Stop();
            }
            else if (received.Equals(_pingMessage))
            {
                odbior.Text += "\n(Odebrano): PAKIET PING";
                prompt.Text += "\nWysłano PONG";
                _modelRS232.CurrentSerial.WriteLine(_pongMessage);
            }
            else if (received.StartsWith("B@ytes:"))
            {
                var binar = received.Substring(7);
                byte[] byt = StringToBytes(binar);

                hexBox2.ByteProvider.InsertBytes(hexBox2.ByteProvider.Length, byt);

                RefreshStream(hexBox2, _receiveMS);
            }
            else
            {
                odbior.Text += "\n(Odebrano):" + received;
            }
        }

        private void HandleElapsedPongTimer(Object source, ElapsedEventArgs e)
        {
            prompt.Text += "\nMinął czas odpowiedzi na PING";
            _pingPongElapsedTimer.Stop();
        }

        private void ChangeGuiState(bool state)
        {
            button1.Enabled = state;
            pingToolStripMenuItem.Enabled = state;
            hexBox1.Enabled = state;
            tabControl1.Enabled = state;
            mODBUSToolStripMenuItem.Enabled = state;
        }

        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prompt.Text += "\nWysłano PING";
            _modelRS232.CurrentSerial.WriteLine(_pingMessage);
            _pingPongStopwatch.Start();
            _pingPongElapsedTimer.Start();
        }

        private string ByteToString(byte[] byteArr)
        {
            StringBuilder sb = new StringBuilder();

            foreach(byte b in byteArr)
            {
                sb.Append((char)b);
            }

            return sb.ToString();
        }

        private byte[] StringToBytes(string input)
        {
            byte[] res = new byte[input.Length];
            int i = 0;
            foreach(char c in input)
            {
                res[i] = (byte)c;
                 ++i;
            }

            return res;
        }

        private void wyslijHex_Click(object sender, EventArgs e)
        {
            hexBox1.ByteProvider.ApplyChanges();
            var bp = hexBox1.ByteProvider as DynamicFileByteProvider;
            var l = hexBox1.ByteProvider.Length;
            byte[] byteArr = new byte[l];

            for(long i = 0;i < l;++i)
            {
                byteArr[i] = bp.ReadByte(i);
            }

            _modelRS232.CurrentSerial.WriteLine("B@ytes:" + ByteToString(byteArr));

            TruncateStream(hexBox1, _sendStream);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            prompt.Text += "\nWystąpił błąd: " + e.ExceptionObject.ToString();
        }

        private void RefreshStream(HexBox hx, MemoryStream str)
        {
            str.Flush();
            str.SetLength(str.Length);
            var bp = hx.ByteProvider as DynamicFileByteProvider;
            hx.ByteProvider.ApplyChanges();
            hx.ByteProvider = hx.ByteProvider;
            hx.Refresh();
            GC.SuppressFinalize(this);
            Thread.Sleep(300);
        }

        private void TruncateStream(HexBox hx, MemoryStream str)
        {
            str.Flush();
            str.SetLength(0);
            var bp = hx.ByteProvider as DynamicFileByteProvider;
            bp.MySuperFlag = true;
            hx.ByteProvider.ApplyChanges();
            bp.MySuperFlag = false;
            hx.ByteProvider = hx.ByteProvider;
            hx.Refresh();
            GC.SuppressFinalize(this);
            Thread.Sleep(300);
        }

        private void mODBUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _modelRS232.DataReceived -= HandleDataReceived;
            var temp = _modelRS232.CurrentSerial.NewLine;
            var m = new Modbus(_modelRS232.CurrentSerial);
            m.ShowDialog();
            _modelRS232.DataReceived -= m.GetMeFaster;
            _modelRS232.CurrentSerial.NewLine = temp;
            _modelRS232.CurrentSerial.Close();
            _modelRS232.CurrentSerial.Open();
            _modelRS232.DataReceived += HandleDataReceived;
        }
    }
}
