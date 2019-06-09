using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Lotnisko
    {
        // X coordinate of airfield
        private int x;
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

        // Y coordinate of airfield
        private int y;
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

        // Name of an airfield
        public string nazwa;

        // Colour of an airfield marker
        public Brush kolor = Brushes.Purple;

        /// <summary>
        /// Airfields constructor
        /// </summary>
        /// <param name="_x">The X coordinate</param>
        /// <param name="_y">The Y coordinate</param>
        /// <param name="_nazwa">Name of an airfield</param>
        public Lotnisko(int _x,int _y,string _nazwa)
        {
            this.X = _x;
            this.Y = _y;
            this.nazwa = _nazwa;
        }
        public Lotnisko()
        {

        }
        public Lotnisko(Lotnisko lotnisko)
        {
             
        }
    }
}
