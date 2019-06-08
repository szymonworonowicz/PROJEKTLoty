using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Samolot:FlyingObject
    {
        protected const double _kat = 80;//degree
        protected const double _przelot = 10000;//m
        protected const int _predkosc = 164;//ms
        public Samolot():base(_kat,_przelot,_predkosc)
        {

        }
        public override string ToString()
        {
            return "Samolot "+base.ToString();
        }
        public override SolidColorBrush ReturnColor()
        {
            return Brushes.Green;
        }
    }
}
