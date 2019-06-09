using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Plane:FlyingObject
    {
        /// <summary>
        /// degree
        /// </summary>
        protected const double _kat = 80;
        /// <summary>
        /// passage
        /// </summary>
        protected const double _przelot = 10000;
        /// <summary>
        /// speed
        /// </summary>
        protected const int _predkosc = 164;
        /// <summary>
        /// Object construktor
        /// </summary>
        public Plane():base(_kat,_przelot,_predkosc)
        {

        }
        /// <summary>
        /// Text representation of object
        /// </summary>
        /// <returns>text representation</returns>
        public override string ToString()
        {
            return "Samolot "+base.ToString();
        }
        /// <summary>
        /// return Colour of an object marker
        /// </summary>
        /// <returns>Colour of an object marker</returns>
        public override SolidColorBrush ReturnColor()
        {
            return Brushes.Green;
        }
    }
}
