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
        protected const double _przelot = 5;//km
        protected const int _predkosc = 300;
        public Awionetka(List<Lotnisko> lotniska) : base(lotniska,_kat,_przelot )
        {
            this.predkosc = _predkosc;
        }
    }
}
