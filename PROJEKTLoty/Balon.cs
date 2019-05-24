using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Balon:ObjektLatajacy
    {
        protected const double kat = 90;
        protected const double przelot = 700;
        public Balon(int _x, int _y, int _z, Lotnisko _start, Lotnisko _finish) : base(_x, _y, _z, _start, _finish)
        {

        }
    }
}
