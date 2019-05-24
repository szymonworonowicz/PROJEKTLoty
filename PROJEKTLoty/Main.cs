using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{ 
    class Main
    {
        static Teren[,] mapa = new Teren[100,100];//kratka 100 km
        private LinkedList<ObjektLatajacy> flying;
        static Main()
        {
            //wczytaj mape
        }
        public Main()
        {
            flying = new LinkedList<ObjektLatajacy>();
            //wartosci
            
        }
        public  void LosujLoty()
        {
            //random do losowania obiektow
            for(int i =0;i<50;i++)
            {
                //switchami dodawac do lsity
                //dla kazdego losuj trase
            }
        }
        public void run()
        {
            //transform pozycji statku
        }
        public void wyswietlmape()
        {
            //wyswietla mape
        }
    }
}
