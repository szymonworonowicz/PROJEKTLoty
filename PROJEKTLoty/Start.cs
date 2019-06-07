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
        //kratka 100 km       
        private LinkedList<ObjektLatajacy> flying;
        static List<Lotnisko> lotniska = new List<Lotnisko>();
        private List<Tuple<int, int>> statyczne;
        public MainWindow win = null;
        public bool start = true;
        private Grid Radar = null;
        public Start()
        {
            win = (MainWindow)Application.Current.MainWindow;//obiekt okienka, wlasciwie to poniekad referencja do niego
            flying = new LinkedList<ObjektLatajacy>();
            statyczne = new List<Tuple<int, int>>();
            Radar = new Grid();
            File();
            InicjalizacjaLotow(); //narazie skomentowane bo robie okno
            Window();
            //Wyswietlmape();
        }
        public void File()
        {
            try
            {
                string line;

                using (StreamReader str = new StreamReader("lotniska.txt"))
                {
                    while ((line = str.ReadLine()) != null)
                    {
                        int x = Convert.ToInt16(line);
                        int y = Convert.ToInt16(str.ReadLine());
                        string nazwa = str.ReadLine();
                        Lotnisko nowe = new Lotnisko(x, y, nazwa);
                        lotniska.Add(nowe);
                    }

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
                    string line;
                    while ((line = str.ReadLine()) != null)
                    {
                        int x = Convert.ToInt16(line);
                        int y = Convert.ToInt16(str.ReadLine());
                        int z = Convert.ToInt16(str.ReadLine());
                        statyczne.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("brak pliku");
            }
            //wczytajmape();
        }

        //private void wczytajmape()
        //{
        //    foreach (var temp in lotniska)
        //    {
        //        TextBlock text = new TextBlock();
        //        text.Background = Brushes.Green;
        //        Grid.SetColumn(text, temp.Y);
        //        Grid.SetRow(text, temp.X);
        //        Radar.Children.Add(text);
        //    }

        //}

        private void InicjalizacjaLotow()
        {
            Random rand = new Random();
            ObjektLatajacy objekt = null;
            int count = 0;
            for (int i = 0; i < 20; i++)
            {
                count = rand.Next(0, 4);
                objekt = null;
                switch (count)
                {
                    case 0:
                        objekt = new Samolot(lotniska);
                        flying.AddLast(objekt);
                        break;
                    case 1:
                        objekt = new Balon(lotniska);
                        flying.AddLast(objekt);
                        break;
                    case 2:
                        objekt = new Awionetka(lotniska);
                        flying.AddLast(objekt);
                        break;
                    case 3:
                        objekt = new Helikopter(lotniska);
                        flying.AddLast(objekt);
                        break;

                }
            }
        }
        public void Window()
        {
            Radar.Background = new SolidColorBrush(Colors.Black);
            Radar.HorizontalAlignment = HorizontalAlignment.Left;
            Radar.Width = 1000;
            Radar.Height = 1000;
            //Create Columns
            for (int i = 0; i < 100; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                Radar.ColumnDefinitions.Add(column);
            }
            //Create Rows
            for (int i = 0; i < 100; i++)
            {
                RowDefinition row = new RowDefinition();
                Radar.RowDefinitions.Add(row);
            }
            win.Left.Content = Radar;
        }
        public void Run()
        {
            while(start==true)
            {
                foreach (var temp in flying)
                {
                    temp.Run();
                }
                Wyswietlmape();
            }
            
        }
        public void Wyswietlmape()
        {
            Radar.Children.Clear();
            for (int i = Radar.Children.Count - 1; i >= 0; --i)
            {
                if (Radar.Children[i].GetType() == typeof(TextBlock))
                {
                    Radar.Children.RemoveAt(i);
                }
            }

            foreach (var temp in lotniska)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.Red;
                Grid.SetColumn(text, temp.Y);
                Grid.SetRow(text, temp.X);
                Radar.Children.Add(text);

            }
            foreach (var temp in statyczne)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.White;
                Grid.SetColumn(text, temp.Item1);
                Grid.SetRow(text, temp.Item2);
                Radar.Children.Add(text);
            }
            Console.WriteLine();
            foreach (var temp in flying)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.BlueViolet;
                Grid.SetColumn(text, Convert.ToInt16(temp.Y));
                Grid.SetRow(text, Convert.ToInt16(temp.X));
                Radar.Children.Add(text);
            }
            win.Left.Content = Radar;
        }
    }
}
