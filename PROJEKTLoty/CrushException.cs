using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKTLoty
{
    class CrushException:Exception
    {
        public CrushException(ObjektLatajacy a, ObjektLatajacy b)
        {
            Window1 window = new Window1(a, b);
            window.Show();
        }
    }
}
