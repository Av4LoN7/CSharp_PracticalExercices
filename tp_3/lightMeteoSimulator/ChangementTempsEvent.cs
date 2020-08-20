using System;
using System.Collections.Generic;
using System.Text;

namespace lightMeteoSimulator
{
    public class ChangementTempsEvent : EventArgs
    {
        public int BeauTemps { get; set; }
        public int MauvaisTemps { get; set; }
    }
}
