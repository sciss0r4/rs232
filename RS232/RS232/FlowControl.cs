using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS232
{
    public class FlowControl
    {
        public Handshake Handshake { get; set; }
        public bool DtrEnable { get; set; }
    }
}
