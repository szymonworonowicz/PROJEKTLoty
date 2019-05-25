using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Samolot:ObjektLatajacy
    {
        protected const double _kat = 45;
        protected const int _przelot = 10000;
        protected const int _predkosc = 700;
        public Samolot(List<Lotnisko> lotniska):base(lotniska)
        {
            this.kat = _kat;
            this.przelot = _przelot;
            this.predkosc = _predkosc;
        }
    }
}
