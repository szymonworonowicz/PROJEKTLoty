using PROJEKTLoty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PROJEKTLoty
{
    public class Main
    {
        //kratka 100 km       
        private List<ObjektLatajacy> flying;
        public static List<Lotnisko> Lotniska = null;
        private List<Tuple<int, int>> statyczne;
        private List<TextBlock> FlyingBlock;
        private List<TextBlock> AirpotrBlock;
        private List<TextBlock> StaticBlock;
        public MainWindow win = null;
        public bool start = true;
        private Grid Radar = null;
        public Main()
        {
            win = (MainWindow)Application.Current.MainWindow;//obiekt okienka, wlasciwie to poniekad referencja do niego
            flying = new List<ObjektLatajacy>();
            Lotniska = new List<Lotnisko>();
            statyczne = new List<Tuple<int, int>>();
            StaticBlock = new List<TextBlock>();
            FlyingBlock = new List<TextBlock>();
            AirpotrBlock = new List<TextBlock>();
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
                        Lotniska.Add(nowe);
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

        }

        private void Wczytajlisty()
        {
            foreach (var temp in flying)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.BlueViolet;
                FlyingBlock.Add(text);
            }
            foreach (var temp in Lotniska)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.Red;
                AirpotrBlock.Add(text);
            }
            foreach (var temo in statyczne)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.White;
                StaticBlock.Add(text);
            }

        }
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
                        objekt = new Samolot();
                        flying.Add(objekt);
                        break;
                    case 1:
                        objekt = new Balon();
                        flying.Add(objekt);
                        break;
                    case 2:
                        objekt = new Awionetka();
                        flying.Add(objekt);
                        break;
                    case 3:
                        objekt = new Helikopter();
                        flying.Add(objekt);
                        break;

                }
            }
            Wczytajlisty();
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
        }
        public void Run()
        {
            while(start==true)
            {
                foreach (var temp in flying)
                {
                    try
                    {
                        temp.Run();
                    }
                    catch (LandingException)
                    {
                        
                    }
                    catch(CrushException)
                    {

                    }
                }
                Wyswietlmape();
                start = false;
            }
            
        }
        public void Wyswietlmape()
        {
            Radar.Children.Clear();
            Radar = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Radar = new Grid();
            Window();
            win.Left.Content = Radar;
            Console.WriteLine("text {0}",flying[1].X);
            int i = 0;
            foreach (var temp in Lotniska)
            {
                
                Grid.SetColumn(AirpotrBlock[i], temp.Y);
                Grid.SetRow(AirpotrBlock[i], temp.X);
                Radar.Children.Add(AirpotrBlock[i]);
                i++; 

            }
            i = 0;
            foreach (var temp in statyczne)
            {
                Grid.SetColumn(StaticBlock[i], temp.Item1);
                Grid.SetRow(StaticBlock[i], temp.Item2);
                Radar.Children.Add(StaticBlock[i]);
                i++;
            }
            i = 0;
            foreach (var temp in flying)
            {
                try
                {
                    Grid.SetColumn(FlyingBlock[i], (int)temp.Y);
                    Grid.SetRow(FlyingBlock[i], (int)temp.X);
                    Radar.Children.Add(FlyingBlock[i]);
                    i++;
                }
                catch (ArgumentException)
                {

                    Console.WriteLine();
                }
                
            }
            win.Left.Content = Radar;
        }
    }
}
