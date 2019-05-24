using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projektv2
{ 
    class Main
    {
        static Teren[,] mapa = new Teren[100,100];//kratka 100 km
        private LinkedList<ObjektLatajacy> flying;
        static readonly List<Lotnisko> lotniska = new List<Lotnisko>();
        static Main()
        {
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    mapa[i, j] = new Teren();
            try
            {
                using (StreamReader str = new StreamReader("lotniska.txt"))
                {
                    int x = Convert.ToInt16(str.ReadLine());
                    int y = Convert.ToInt16(str.ReadLine());
                    string nazwa = str.ReadLine();
                    Lotnisko nowe = new Lotnisko(x, y, nazwa);
                    lotniska.Add(nowe);
                    mapa[x, y].lotnisko = nowe;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("brak pliku");
            }
            try
            {
                using (StreamReader str = new StreamReader("obiektystatyczne.txt"))
                {
                    int x = Convert.ToInt16(str.ReadLine());
                    int y = Convert.ToInt16(str.ReadLine());
                    int z = Convert.ToInt16(str.ReadLine());
                    ObjektStatyczny nowy = new ObjektStatyczny(z);
                    if (mapa[x, y].lotnisko != null)
                        mapa[x, y].objekt = nowy;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("brak pliku");
            }
        }
        public Main()
        {
            flying = new LinkedList<ObjektLatajacy>();
            
        }
        public  void InicjalizacjaLotow()
        {
            Random rand = new Random();
            ObjektLatajacy latajacy=null;
            for(int i =0;i<50;i++)
            {
                int count = rand.Next(0, 3);
                switch (count)
                {
                    case 0:
                        latajacy = new Samolot(lotniska);
                            break;
                    case 1:
                        latajacy = new Balon(lotniska);
                        break;
                    case 2:
                        latajacy = new Awionetka(lotniska);
                        break;
                    case 3:
                        latajacy = new Helikopter(lotniska);
                        break;
                        
                }
                flying.AddLast(latajacy);
            }
        }
        public void run()
        {
            //transform pozycji statku
        }
        private void wyswietlmape()
        {
            //wyswietla mape
        }
    }
}
