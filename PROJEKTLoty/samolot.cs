using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Samolot:ObjektLatajacy
    {
        protected const double _kat = 80;
        protected const double _przelot = 10;
        protected const int _predkosc = 700;
        public Samolot(List<Lotnisko> lotniska):base(lotniska,_kat,_przelot)
        {
            this.predkosc = _predkosc;
        }
    }
}
