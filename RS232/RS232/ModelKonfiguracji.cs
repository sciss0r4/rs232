using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS232
{
    public class ModelKonfiguracji
    {
        public string Port { get; set; }
        public int Speed { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public int StopBits { get; set; }
        public FlowControl FlowControl { get; set; }
        public string Terminator { get; set; }
    }
}
