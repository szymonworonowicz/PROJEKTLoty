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
        protected const double _kat = 85;//degree
        protected const double _przelot = 700;//m
        protected const int _predkosc = 14;//m/s
        public Balon() : base(_kat,_przelot,_predkosc)
        {

        }
    }
}
