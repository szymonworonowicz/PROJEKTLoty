using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Balon:ObjektLatajacy
    {
        protected const double _kat = 85;
        protected const double _przelot = 0.7d;
        protected const int _predkosc = 50;
        public Balon(List<Lotnisko> lotniska) : base(lotniska,_kat,_przelot)
        {
            this.predkosc = _predkosc;
        }
    }
}
