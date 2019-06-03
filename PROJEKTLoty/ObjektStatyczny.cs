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
        private int x,z, y;
       //kolor znaczka
        public int X { get=>x; private set =>x=value; }
        public int Y { get => y; private set => y = value; }
        public ObjektStatyczny(int _z,int _x,int _y)
        {
            this.z = _z;
            this.y = _y;
            this.X = _x;
        }

    }
}
