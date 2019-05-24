using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    abstract class ObjektLatajacy
    {
        protected int x, y, z;
        protected Lotnisko Start, Finish;
        public ObjektLatajacy(int _x,int _y,int _z, Lotnisko _start , Lotnisko _finish)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
            Start = _start;

        }
        public Tuple<Lotnisko,Lotnisko> LosujTrase(LinkedList<Lotnisko> lotniska)
        {
            //randomowo loswanie 
            
            return new Tuple<Lotnisko, Lotnisko>(new Lotnisko(),new Lotnisko());
        }
        public void run()//transform pozycji
        {

        }
        public Tuple<int,int> przewidzpozycje(ObjektLatajacy objekt)
        {
            //za 3 tiki
            return new Tuple<int, int>(1,1);
        }
        public void zblizenie()
        {
            //zmiana awaryjna kursu
        }
        public void jakzmienickurs()
        {

        }
        private  void start()
        {

        }
        private void finish()
        {

        }
    }
}
