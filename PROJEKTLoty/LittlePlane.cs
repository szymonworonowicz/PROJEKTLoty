using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace PROJEKTLoty
{ 
    class LittlePlane:FlyingObject
    {
        /// <summary>
        /// degree
        /// </summary>
        protected const double _degree = 65;
        /// <summary>
        /// passage
        /// </summary>
        protected const double _passage = 5000;
        /// <summary>
        /// speed
        /// </summary>
        protected const int _speed = 84;
        /// <summary>
        /// Object construktor
        /// </summary>
        public LittlePlane() : base(_degree,_passage,_speed)
        {
            
        }
        /// <summary>
        /// Text representation of object
        /// </summary>
        /// <returns>text representation</returns>
        public override string ToString()
        {
            return "Awionetka " + base.ToString();
        }
        /// <summary>
        /// return Colour of an object marker
        /// </summary>
        /// <returns>Colour of an object marker</returns>
        public override SolidColorBrush ReturnColor()
        {
            return Brushes.Purple;
        }
    }
}
