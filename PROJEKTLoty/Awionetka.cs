using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace PROJEKTLoty
{ 
    class Awionetka:ObjektLatajacy
    {
        protected const double _kat = 65;
        protected const int _przelot = 5000;
        protected const int _predkosc = 300;
        static Brush kolor = Brushes.Yellow;//kolor znaczka
        public Awionetka(List<Lotnisko> lotniska) : base(lotniska,_kat,_przelot,kolor )
        {
            this.predkosc = _predkosc;
        }
    }
}
