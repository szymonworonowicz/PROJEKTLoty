using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Awionetka:ObjektLatajacy
    {
        protected const double _kat = 15;
        protected const int _przelot = 5000;
        protected const int _predkosc = 300;
        public Awionetka(List<Lotnisko> lotniska) : base(lotniska)
        {
            this.kat = _kat;
            this.przelot = _przelot;
            this.predkosc = _predkosc;
        }
    }
}
