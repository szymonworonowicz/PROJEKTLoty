using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    abstract class ObjektLatajacy
    {
        protected int x, y, z,przelot,predkosc;
        protected double kat;
        protected Lotnisko Start, Finish;
        public ObjektLatajacy(List<Lotnisko> lotniska)
        {
            LosujTrase(lotniska);
        }
        private static void LosujTrase(List<Lotnisko> lotniska)
        {
            
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
