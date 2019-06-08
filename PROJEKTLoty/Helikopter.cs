using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Helikopter:FlyingObject
    {
        protected const double _kat = 80;//degree
        protected const double _przelot = 2000;//m
        protected const int _predkosc = 139;//m/s
        public Helikopter():base(_kat,_przelot,_predkosc)
        {
            
        }
        public override string ToString()
        {
            return "Helikopter "+base.ToString();
        }
    }
}
