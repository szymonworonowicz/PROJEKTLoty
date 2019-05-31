using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKTLoty
{
    class Helikopter:ObjektLatajacy
    {
        protected const double _kat = 80;
        protected const int _przelot = 2000;
        protected const int _predkosc = 500;
        public Helikopter(List<Lotnisko> lotniska):base(lotniska,_kat,_predkosc)
        {
            this.przelot = _przelot;
        }
    }
}
