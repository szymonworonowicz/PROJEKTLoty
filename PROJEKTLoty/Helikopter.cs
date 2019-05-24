using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Helikopter:ObjektLatajacy
    {
        protected const double _kat = 80;
        protected const int _przelot = 2000;
        protected const int _predkosc = 500;
        public Helikopter(List<Lotnisko> lotniska):base(lotniska)
        {
            this.kat = _kat;
            this.przelot = _przelot;
            this.predkosc = _predkosc;
        }
    }
}
