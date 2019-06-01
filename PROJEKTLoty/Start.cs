using PROJEKTLoty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PROJEKTLoty
{
    public class Start
    {
        static readonly Teren[,] mapa = new Teren[100, 100];//kratka 100 km       
        private LinkedList<ObjektLatajacy> flying;
        static readonly List<Lotnisko> lotniska = new List<Lotnisko>();
        public MainWindow win = null;
        static Start()
        {
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    mapa[i, j] = new Teren();
            try
            {
                string line;

                using (StreamReader str = new StreamReader("lotniska.txt",true))
                {
                    while((line=str.ReadLine())!=null)
                    {
                        int x = Convert.ToInt16(line);
                        int y = Convert.ToInt16(str.ReadLine());
                        string nazwa = str.ReadLine();
                        Lotnisko nowe = new Lotnisko(x, y, nazwa);
                        lotniska.Add(nowe);
                        mapa[x, y].lotnisko = nowe;
                    }
                    
                }
            }

            catch (IOException)
            {
                Console.WriteLine("brak pliku");
            }
            try
            {
                using (StreamReader str = new StreamReader("obiektystatyczne.txt",true))
                {
                    string line;
                    while(( line=str.ReadLine())!=null)
                    {
                        int x = Convert.ToInt16(line);
                        int y = Convert.ToInt16(str.ReadLine());
                        int z = Convert.ToInt16(str.ReadLine());
                        ObjektStatyczny nowy = new ObjektStatyczny(z);
                        if (mapa[x, y].lotnisko != null)
                            mapa[x, y].objekt = nowy;
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("brak pliku");
            }
        }
        public Start()
        {
            win = (MainWindow)Application.Current.MainWindow;//obiekt okienka, wlasciwie to poniekad referencja do niego
            //flying = new LinkedList<ObjektLatajacy>();
            //InicjalizacjaLotow(); narazie skomentowane bo robie okno
            Window();
            Wyswietlmape();
        }
        public void InicjalizacjaLotow()
        {
            Random rand = new Random();
            ObjektLatajacy latajacy = null;
            for (int i = 0; i < 50; i++)
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
        public void Window()
        {

            win.DynamicGrid.ShowGridLines = true;
            win.DynamicGrid.Background = new SolidColorBrush(Colors.Black);
            //Create Columns
            for (int i = 0; i < 100; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                win.DynamicGrid.ColumnDefinitions.Add(column);
            }
            //Create Rows
            for (int i = 0; i < 100; i++)
            {
                RowDefinition row = new RowDefinition();
                win.DynamicGrid.RowDefinitions.Add(row);
            }
        }
        public void Run()
        {

        }
        public void Wyswietlmape()
        {
            //foreach(Lotnisko temp in lotniska)
            //{
            //    TextBlock text = new TextBlock();
            //    text.Foreground = Brushes.Red;
            //    Grid.SetColumn(text, temp.Y);
            //    Grid.SetRow(text, temp.X);
            //    win.DynamicGrid.Children.Add(text);
            //}
            foreach(var temp in flying)
            {
                TextBlock text = new TextBlock();
                text.Foreground = Brushes.Red;
                Grid.SetColumn(text, Convert.ToInt16(temp.Y));
                win.DynamicGrid.Children.Add(text);
            }

        }
    }
}
