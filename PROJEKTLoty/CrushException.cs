using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKTLoty
{
    class CrushException:Exception
    {
        /// <summary>
        /// exception to changing altitude in the event of a collision
        /// </summary>
        /// <param name="a">first object</param>
        /// <param name="b">second object</param>
        public CrushException(FlyingObject a, FlyingObject b)
        {
            Window1 window = new Window1(a, b);
            window.Show();
        }
    }
}
