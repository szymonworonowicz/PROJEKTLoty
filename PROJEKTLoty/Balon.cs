using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Balon:ObjektLatajacy
    {
        protected const double _kat = 90;
        protected const int _przelot = 700;
        protected const int _predkosc = 50;
        public Balon(List<Lotnisko> lotniska) : base(lotniska,_kat,_predkosc)
        {
            this.przelot = _przelot;
        }
    }
}
