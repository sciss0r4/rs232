using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace RS232
{
    public partial class Modbus : Form
    {
        private SerialPort _serialPort;
        public SerialDataReceivedEventHandler GetMeFaster;
        private string _previouslySentMessage = String.Empty;
        private System.Timers.Timer _transactionTimer = new System.Timers.Timer();
        private int _retryCount = 0;
        private bool _acceptResponse = false;
        public Modbus(SerialPort sp)
        {

            InitializeComponent();
            _serialPort = sp;
            _serialPort.NewLine = "\r\n";
            GetMeFaster = HandleDataReceived;
            _serialPort.DataReceived += GetMeFaster;
            _serialPort.Close();
            _serialPort.Open();
            _transactionTimer.Elapsed += HandleElapsedTransactionTimer;
            _transactionTimer.AutoReset = false;
            //_currentSerial.BaudRate = conf.Speed;
            //_currentSerial.ReadTimeout = 10000;
            //_currentSerial.WriteTimeout = 10000;
        }

        private void HandleElapsedTransactionTimer(Object source, ElapsedEventArgs e)
        {
            // HANDLE
            //_serialPort.Close();
            //_serialPort.Open();
            _acceptResponse = false;
            Thread.Sleep(500);
            MessageBox.Show("Minął czas odpowiedzi...");

            if (_retryCount < Retransmisje)
            {
                ++_retryCount;
                button1_Click(null, null);
            }
        }

        public int Timeout
        {
            get { return (int)numericUpDown4.Value; }
        }

        public int Retransmisje
        {
            get { return (int)numericUpDown5.Value; }
        }

        private string ByteToString(byte[] byteArr)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in byteArr)
            {
                sb.Append((char)b);
            }

            return sb.ToString();
        }

        private byte[] StringToBytes(string input)
        {
            byte[] res = new byte[input.Length];
            int i = 0;
            foreach (char c in input)
            {
                res[i] = (byte)c;
                ++i;
            }

            return res;
        }

        private void HandleDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _transactionTimer.Stop();

            if(comboBox1.SelectedItem.ToString() == "Slave")
            {
                var received = _serialPort.ReadLine();
                byte[] message = HexStringToByteArray(received);

                if(message[1] == numericUpDown3.Value)
                {
                    listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Odebrano): " + received + "1310");

                    if (message[0] != (byte)':')
                    {
                        MessageBox.Show("Odebrano ramkę z nieprawidłowym znacznikiem początku!");
                    }

                    if (message[2] == 1)
                    {
                        byte [] temp = new byte[message.Length-4];
                        for(int i = 3;i < message.Length-1;++i)
                        {
                            temp[i-3] = message[i];
                        }

                        richTextBox2.Text += "\n" + ByteToString(temp);
                        _serialPort.WriteLine(ByteArrayToString(message));
                        listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Wysłano): " + received + "1310");
                    }
                    else if (message[2] == 2)
                    {
                        var txtLength = richTextBox1.Text.Length;
                        var messageLength = 4 + txtLength;
                        byte[] msg = new byte[messageLength];
                        msg[0] = (byte)':';
                        msg[1] = message[1];
                        msg[2] = 2;

                        for (int i = 3; i < txtLength + 3; ++i)
                        {
                            msg[i] = (byte)richTextBox1.Text[i - 3];
                        }

                        msg[messageLength - 1] = LRC(richTextBox1.Text);

                        var toSend = ByteArrayToString(msg);
                        listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Wysłano): " + toSend + "1310");
                        _serialPort.WriteLine(toSend);
                    }
                }
                else if (message[1] == 0)
                {
                    listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Odebrano Broadcast): " + received + "1310");

                    if (message[0] != (byte)':')
                    {
                        MessageBox.Show("Odebrano ramkę z nieprawidłowym znacznikiem początku!");
                    }

                    byte[] temp = new byte[message.Length - 4];
                    for (int i = 3; i < message.Length - 1; ++i)
                    {
                        temp[i - 3] = message[i];
                    }

                    richTextBox2.Text += "\n" + ByteToString(temp);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Master")
            {
                var received = _serialPort.ReadLine();

                if (_acceptResponse)
                {
                    _acceptResponse = false;

                    if (received == _previouslySentMessage)
                    {
                        listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Odebrano): " + received + "1310");
                    }
                    else
                    {
                        byte[] message = HexStringToByteArray(received);

                        if (message[2] == 2)
                        {
                            byte[] temp = new byte[message.Length - 4];
                            for (int i = 3; i < message.Length - 1; ++i)
                            {
                                temp[i - 3] = message[i];
                            }

                            richTextBox2.Text += "\n" + ByteToString(temp);

                            listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Odebrano): " + received + "1310");
                        }
                    }
                }
            }
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            if(comboBox1.SelectedItem.ToString() == "Master")
            {
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
                if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() == "Adresowana")
                {
                    numericUpDown4.Enabled = true;
                    numericUpDown5.Enabled = true;
                }
            }
            else if(comboBox1.SelectedItem.ToString() == "Slave")
            {
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            if(comboBox2.SelectedItem.ToString() == "Adresowana")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = true;
                numericUpDown2.Value = 1;
                numericUpDown2.Minimum = 1;
                numericUpDown2.Maximum = 2;
                label6.Text = "Wysłanie tekstu do stacji Slave";
            }
            else if(comboBox2.SelectedItem.ToString() == "Rozgłoszeniowa")
            {
                numericUpDown2.Enabled = true;
                numericUpDown2.Value = 1;
                numericUpDown2.Minimum = 1;
                numericUpDown2.Maximum = 1;
                label6.Text = "Wysłanie tekstu do stacji Slave";
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = "-- Brak --";

            if(numericUpDown2.Value == 1)
            {
                label6.Text = "Wysłanie tekstu do stacji Slave";
            }
            else if (numericUpDown2.Value == 2)
            {
                label6.Text = "Odczyt tekstu ze stacji Slave";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;

            if (comboBox2.SelectedItem == null)
                return;

            if ((comboBox2.SelectedItem.ToString() == "Rozgłoszeniowa" || comboBox2.SelectedItem.ToString() == "Adresowana") && !String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _transactionTimer.Stop();

            if (Timeout <= 0)
            {
                richTextBox2.Text += "\n Interwał 0, minął czas odpowiedzi...";
                return;
            }

            if (sender != null)
            {
                _retryCount = 0;
            }

            _transactionTimer.Interval = Timeout;

            if (numericUpDown2.Value == 1)
            {
                var message = PrepareMessage();
                _previouslySentMessage = message;
                listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Wysłano): " + message + "1310");
                _serialPort.WriteLine(message);
            }
            else if (numericUpDown2.Value == 2)
            {
                var message = PrepareReadMessage();
                listBox1.Items.Add("[" + listBox1.Items.Count.ToString() + "] (Wysłano): " + message + "1310");
                _serialPort.WriteLine(message);
            }

            _acceptResponse = true;
            _transactionTimer.Start();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private string PrepareReadMessage()
        {
            var messageLength = 4;
            byte[] message = new byte[messageLength];
            message[0] = (byte)':';
            message[1] = comboBox2.SelectedItem.ToString() == "Adresowana" ? (byte)numericUpDown1.Value : (byte)0;
            message[2] = (byte)numericUpDown2.Value;
            message[3] = 0;

            return ByteArrayToString(message);
        }

        private string PrepareMessage()
        {
            var txtLength = richTextBox1.Text.Length;
            var messageLength = 4 + txtLength;
            byte[] message = new byte[messageLength];
            message[0] = (byte)':';
            message[1] = comboBox2.SelectedItem.ToString() == "Adresowana" ? (byte)numericUpDown1.Value : (byte)0;
            message[2] = (byte)numericUpDown2.Value;

            for (int i = 3; i < txtLength + 3; ++i)
            {
                message[i] = (byte)richTextBox1.Text[i - 3];
            }

            message[messageLength - 1] = LRC(richTextBox1.Text);

            return ByteArrayToString(message);
        }

        private byte LRC (string text)
        {
            byte LRC = 0;

            for (int i = 0; i < text.Length; i++)
            {
                LRC ^= (byte)text[i];
            }

            return LRC;
        }
    }
}
