using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS232
{
    public partial class Konfiguracja : Form
    {
        public ModelKonfiguracji ModelKonfiguracji { get; set; }
        public Konfiguracja()
        {
            InitializeComponent();
            ModelKonfiguracji = null;
            foreach (string s in SerialPort.GetPortNames())
                portBox.Items.Add(s);

            speedBox.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200"});

            dataBox.Items.AddRange(new object[] {
            "7 b",
            "8 b"
            });

            controlBox.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"
            });

            stopBox.Items.AddRange(new object[] {
            "1 b",
            "2 b"
            });

            flowBox.Items.AddRange(new object[] {
            "Brak",
            "DTR/DSR",
            "RTS/CTS",
            "XON/XOFF"
            });

            termBox.Items.AddRange(new object[] {
            "CR",
            "LF",
            "CR-LF",
            "Własny"
            });

            portBox.SelectedIndex = 0;
            speedBox.SelectedIndex = 0;
            dataBox.SelectedIndex = 0;
            controlBox.SelectedIndex = 0;
            stopBox.SelectedIndex = 0;
            flowBox.SelectedIndex = 0;
            termBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModelKonfiguracji = new ModelKonfiguracji();
            // Wypelnij model konfiguracji
            ModelKonfiguracji.Port = portBox.SelectedItem != null ? portBox.SelectedItem.ToString() : String.Empty;
            ModelKonfiguracji.Speed = speedBox.SelectedItem != null ? Int32.Parse(speedBox.SelectedItem.ToString()) : 0;
            ModelKonfiguracji.DataBits = dataBox.SelectedItem != null ? Int32.Parse(dataBox.SelectedItem.ToString()[0].ToString()) : 0;
            ModelKonfiguracji.Parity = (Parity)dataBox.SelectedIndex;
            ModelKonfiguracji.StopBits = stopBox.SelectedItem != null ? Int32.Parse(stopBox.SelectedItem.ToString()[0].ToString()) : 0;
            ModelKonfiguracji.FlowControl = flowBox.SelectedItem != null ? FlowControlMapper.Map(flowBox.SelectedItem.ToString()) : null;
            ModelKonfiguracji.Terminator = termBox.SelectedItem != null ? TerminatorMapper.Map(termBox.SelectedItem.ToString(), termText.Text) : null;

            // Waliduj model konfiguracji
            if(!ModelKonfiguracjiValidator.Validate(ModelKonfiguracji))
            {
                //Obsłuż nieprawidłową walidację
                MessageBox.Show("Wprowadzono niepoprawne dane konfiguracyjne!");
                return;
            }

            this.Close();
        }

        private void termBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //Sprawdź czy własny znak został wybrany 
            termText.Enabled = termBox.SelectedItem != null && termBox.SelectedItem.ToString().Equals("Własny");
        }
    }
}
