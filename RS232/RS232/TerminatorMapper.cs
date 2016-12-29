using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS232
{
    public class TerminatorMapper
    {
        public static string Map(string option,string term)
        {
            char CR = (char)13;
            char LF = (char)10;

            switch (option)
            {
                case "Brak": return String.Empty;
                case "CR": return CR.ToString();
                case "LF": return LF.ToString();
                case "CR-LF": return new string(new char[] {CR,LF} );
                case "Własny": return term;
            }

            return String.Empty;
        }
    }
}
