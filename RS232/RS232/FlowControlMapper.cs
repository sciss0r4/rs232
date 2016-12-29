using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS232
{
    public class FlowControlMapper
    {
        public static FlowControl Map (string flow)
        {
            var flowCtrl = new FlowControl() { Handshake = Handshake.None, DtrEnable = false };

            switch (flow)
            {
                case "DTR/DSR": flowCtrl.DtrEnable = true; break;
                case "RTS/CTS": flowCtrl.Handshake = Handshake.RequestToSend; break;
                case "XON/XOFF": flowCtrl.Handshake = Handshake.XOnXOff; break;
            }

            return flowCtrl;
        }
    }
}
