using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Teren
    {
        public Lotnisko lotnisko;
        public ObjektStatyczny objekt;
        public Teren(Lotnisko _lotnisko,ObjektStatyczny objekt)
        {
            this.lotnisko = new Lotnisko(_lotnisko);
            this.objekt = new ObjektStatyczny(objekt);
        }
    }
}
