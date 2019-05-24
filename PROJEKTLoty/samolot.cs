using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class samolot:ObjektLatajacy
    {
        protected const double _kat = 15;
        protected const int _przelot = 10000;
        protected const int _predkosc = 700;
        public samolot(int _x, int _y, int _z, Lotnisko _start, Lotnisko _finish):base(_x,_y,_z,_start,_finish)
        {
            this.kat = _kat;
            this.przelot = _przelot;
            this.predkosc = _predkosc;
        }
    }
}
