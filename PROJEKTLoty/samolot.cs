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
        protected const double _kat = 45;
        protected const int _przelot = 10000;
        protected const int _predkosc = 700;
        static Brush kolor = Brushes.Brown;//kolor znaczka
        public Samolot(List<Lotnisko> lotniska):base(lotniska,_kat,_przelot,kolor)
        {
            this.predkosc = _predkosc;
        }
    }
}
