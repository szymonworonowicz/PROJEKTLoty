using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class samolot:ObjektLatajacy
    {
        protected const double kat = 15;
        protected const int przelot = 10000;
        public samolot(int _x, int _y, int _z, Lotnisko _start, Lotnisko _finish):base(_x,_y,_z,_start,_finish)
        {

        }
    }
}
