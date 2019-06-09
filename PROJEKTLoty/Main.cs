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
    /// <summary>
    /// Main class of the Program
    /// </summary>
    public class Main
    {
        /// <summary>
        /// list of flying objects
        /// </summary>
        public static List<FlyingObject> flying;
        /// <summary>
        /// static list of Aircrafts
        /// </summary>
        public static List<Airport> Aircrafts;
        /// <summary>
        /// list of static object
        /// </summary>
        private List<Tuple<int, int>> staticobject;
        /// <summary>
        /// List of TextBlocks to draw FlyingObject on the map 
        /// </summary>
        private List<TextBlock> FlyingBlock;
        /// <summary>
        /// List of TextBlocks to draw AirCrafts on the map 
        /// </summary>
        private List<TextBlock> AirportBlock;
        /// <summary>
        /// List of TextBlocks to draw static object on the map
        /// </summary>        
        private List<TextBlock> StaticBlock;
        /// <summary>
        /// reference to MainWindow window
        /// </summary>
        public MainWindow win = null;
        /// <summary>
        /// Grid for creating a map 
        /// </summary>
        private Grid Radar = null;
        /// <summary>
        /// Construktor
        /// </summary>
        public Main()
        {
            win = (MainWindow)Application.Current.MainWindow;//obiekt okienka, wlasciwie to poniekad referencja do niego
            flying = new List<FlyingObject>();
            Aircrafts = new List<Airport>();
            staticobject = new List<Tuple<int, int>>();
            StaticBlock = new List<TextBlock>();
            FlyingBlock = new List<TextBlock>();
            AirportBlock = new List<TextBlock>();
            Radar = new Grid();
            File();
            InicjalizacjaLotow(); //narazie skomentowane bo robie okno
            Window();
        }

        /// <summary>
        /// Reading airfields and static objects from files
        /// </summary>
        /// <exception cref="IOException"/>
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
                        Airport nowe = new Airport(x, y, nazwa);
                        Aircrafts.Add(nowe);
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
                        staticobject.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("brak pliku");
            }

        }
        /// <summary>
        /// Inicialization of TextBlocks list
        /// </summary>
        private void Wczytajlisty()
        {
            
            foreach (var temp in flying)
            {
                TextBlock text = new TextBlock();
                text.Background = temp.ReturnColor() ;
                FlyingBlock.Add(text);
            }
            foreach (var temp in Aircrafts)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.Red;
                AirportBlock.Add(text);
            }
            foreach (var temo in staticobject)
            {
                TextBlock text = new TextBlock();
                text.Background = Brushes.White;
                StaticBlock.Add(text);
            }

        }
        /// <summary>
        /// Initiating flying object list
        /// </summary>
        private void InicjalizacjaLotow()
        {
            Random rand = new Random();
            FlyingObject objekt = null;
            int count = 0;
            for (int i = 0; i < 20; i++)
            {
                count = rand.Next(0, 4);
                objekt = null;
                switch (count)
                {
                    case 0:
                        objekt = new Plane();
                        flying.Add(objekt);
                        break;
                    case 1:
                        objekt = new Balloon();
                        flying.Add(objekt);
                        break;
                    case 2:
                        objekt = new LittlePlane();
                        flying.Add(objekt);
                        break;
                    case 3:
                        objekt = new Helicopter();
                        flying.Add(objekt);
                        break;

                }
            }
            Wczytajlisty();
        }
        /// <summary>
        /// Generation of the MainWindow 
        /// </summary>
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
        /// <summary>
        /// Transform the List of FlyingObject
        /// </summary>
        /// <exception cref="CrushException"/>

        public void Run()
        { 
            for(int i=0;i<2;i++)
                foreach (var temp in flying)
                {
                    try
                    {
                        temp.Run();
                    }
                    catch(CrushException)
                    {

                    }
                }
            Thread.Sleep(10);
            DrawMap();
        }
        /// <summary>
        /// Draw a map
        /// </summary>
        /// <exception cref="ArgumentException"/>
        public void DrawMap()
        {
            Radar.Children.Clear();
            int i = 0;
            foreach (var temp in Aircrafts)
            {
                AirportBlock[i].Text = (i + 1).ToString();
                AirportBlock[i].FontSize =7;
                Grid.SetColumn(AirportBlock[i], temp.Y);
                Grid.SetRow(AirportBlock[i], temp.X);
                Radar.Children.Add(AirportBlock[i]);
                i++; 

            }
            i = 0;
            foreach (var temp in staticobject)
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
                    
                }
                
            }
            win.Left.Content = Radar;
        }
    }
}
