using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class ObjektStatyczny
    {
        // Objects position with z as its height
        private int x,z, y;
        public int X { get=>x; private set =>x=value; }
        public int Y { get => y; private set => y = value; }

        /// <summary>
        /// Constructor of static object
        /// </summary>
        /// <param name="_z">Height of an object</param>
        /// <param name="_x">X coordinate of an object</param>
        /// <param name="_y">Y coordinate of an object</param>
        public ObjektStatyczny(int _z,int _x,int _y)
        {
            this.z = _z;
            this.y = _y;
            this.X = _x;
        }

    }
}
