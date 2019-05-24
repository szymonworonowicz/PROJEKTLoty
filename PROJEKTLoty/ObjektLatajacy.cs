using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    abstract class ObjektLatajacy
    {
        protected int x, y, z ,przelot , predkosc;
        protected double kat;
        protected Lotnisko _Start=null, _Finish=null;
        public ObjektLatajacy(List<Lotnisko> lotniska)
        {
            _Start=LosujLotnisko(lotniska);
            x = _Start.X;
            y = _Start.Y;
            z = 0;
            _Finish = LosujLotnisko(lotniska);
        }
        private  Lotnisko LosujLotnisko(List<Lotnisko> lotniska)
        {
            Random rand = new Random();
            int i=0;
            do
            {
                i = rand.Next(0, lotniska.Count - 1);
            } while (_Start == lotniska[i]);
            return lotniska[i] ;
        }
        public void Run()//transform pozycji
        {
            bool Czy_wystartowal = false;
            if (z < przelot)
                Start();
            else if (z == przelot)
            {
                Czy_wystartowal = true;
                Lot();
            } 
            else if(Czy_wystartowal==true)
                Finish();
        }

        private void Lot()
        {
            
        }

        public Tuple<int,int> Przewidzpozycje(ObjektLatajacy objekt)
        {
            //za 3 tiki
            return new Tuple<int, int>(1,1);
        }
        public void Zblizenie()
        {
            //zmiana awaryjna kursu
        }
        public void Jakzmienickurs()
        {

        }
        private  void Start()
        {

        }
        private void Finish()
        {

        }
    }
}
