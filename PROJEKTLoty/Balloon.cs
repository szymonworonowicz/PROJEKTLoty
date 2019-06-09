using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Balloon:FlyingObject
    {        
        /// <summary>
        /// degree
        /// </summary>
        protected const double _degree = 85;
        /// <summary>
        /// passage
        /// </summary>
        protected const double passage = 700;
        /// <summary>
        /// speed
        /// </summary>
        protected const int _speed = 14;
        /// <summary>
        /// Object construktor
        /// </summary>
        public Balloon() : base(_degree,passage,_speed)
        {

        }
        /// <summary>
        /// Text representation of object
        /// </summary>
        /// <returns>text representation</returns>
        public override string ToString()
        {
            return " Balon "+ base.ToString();
        }
        /// <summary>
        /// return Colour of an object marker
        /// </summary>
        /// <returns>Colour of an object marker</returns>
        public override SolidColorBrush ReturnColor()
        {
            return Brushes.Blue;
        }
    }
}
