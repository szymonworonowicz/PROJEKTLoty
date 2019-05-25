using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{
    abstract class ObjektLatajacy
    {
        protected int x, y, z ,przelot , predkosc,odl;
        protected double kat;
        protected Lotnisko _Start=null, _Finish=null;
        public ObjektLatajacy(List<Lotnisko> lotniska)
        {
            _Start=LosujLotnisko(lotniska);
            x = _Start.X;
            y = _Start.Y;
            z = 0;
            _Finish = LosujLotnisko(lotniska);
            odl=OdlLotniska();
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
            if (z < przelot && Czy_wystartowal==false)
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
        private int OdlLotniska()
        {
            return Math.Round(Math.Sqrt(Math.Pow(_Start.X-_Finish.X,2)+Math.Pow(_Start.Y-_Finish.Y,2))));
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
        private  void Start()//tick 20 s
        {
            double time =20;//s
            double skos=predkosc*time;
            double changewys=Math.Round(Math.Sin(kat)*skos);
            double changedis=Math.Round(Math.Cos(kat)*skos);
            z+=changewys;

            
        }
        private void Finish()
        {

        }
    }
}
