using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekGrapher.ImageConverterCore
{
    public class CMYKColor
    {
        public byte Cyan { get; set; }
        public byte Magenda { get; set; }
        public byte Yellow { get; set; }
        public byte Black { get; set; }

        public CMYKColor(byte c, byte m, byte y, byte k)
        {
            Cyan = c;
            Magenda = m;
            Yellow = y;
            Black = k;
        }
    }
}
