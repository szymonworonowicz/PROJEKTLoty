using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class ObjektStatyczny
    {
        public int z;
        public ObjektStatyczny()
        {

        }
        public ObjektStatyczny(int _z)
        {
            this.z = _z;
        }
        public ObjektStatyczny(ObjektStatyczny objekt)
        {

        }
    }
}
