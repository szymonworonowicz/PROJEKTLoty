using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    class Lotnisko
    {
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
        private int y;
        public int Y { get=>y; private set => y = value; }
        public string nazwa;
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
