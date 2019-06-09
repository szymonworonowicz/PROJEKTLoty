using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Helicopter:FlyingObject
    {
        /// <summary>
        /// degree
        /// </summary>
        protected const double _degree = 80;
        /// <summary>
        /// passage
        /// </summary>
        protected const double _passage = 2000;
        /// <summary>
        /// speed
        /// </summary>
        protected const int _speed = 139;
        /// <summary>
        /// Object construktor
        /// </summary>
        public Helicopter():base(_degree,_passage,_speed)
        {}
        /// <summary>
        /// Text representation of object
        /// </summary>
        /// <returns>text representation</returns>
        public override string ToString()
        {
            return "Helikopter "+base.ToString();
        }
        /// <summary>
        /// return Colour of an object marker
        /// </summary>
        /// <returns>Colour of an object marker</returns>
        public override SolidColorBrush ReturnColor()
        {
            return Brushes.Yellow;
        }
    }
}
