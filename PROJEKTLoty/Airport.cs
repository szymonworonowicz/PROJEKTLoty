using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    /// <summary>
    /// Aircraft class
    /// </summary>
    public class Airport
    {
        /// <summary>
        ///  X coordinate of airfield
        /// </summary>
        private int x;
        /// <value> x value</value>
        public int X
        {
            get
            {
                return x;
            }
            private set
            {
                x = value;
            }
        }
        /// <summary>
        ///  Y coordinate of airfield
        /// </summary>
        private int y;
        /// <value> y value</value>
        public int Y
        {
            get
            {
                return y;
            }
            private set
            {
                y = value;
            }
        }
        /// <summary>
        /// name of the aircraft
        /// </summary>
        public string name;
        /// <summary>
        /// Airfields constructor
        /// </summary>
        /// <param name="_x">The X coordinate</param>
        /// <param name="_y">The Y coordinate</param>
        /// <param name="_nazwa">Name of an airfield</param>
        public Airport(int _x,int _y,string _nazwa)
        {
            this.X = _x;
            this.Y = _y;
            this.name = _nazwa;
        }

        /// <summary>
        /// Return String representation of Airport
        /// </summary>
        /// <returns> String representation of Airport</returns>
        public override string ToString()
        {
            return name + " (" + x + "," + y + ") ";  
        }
    }
}
