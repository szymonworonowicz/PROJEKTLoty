using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    abstract class ObjektLatajacy
    {
        // A wway to count how many tics therre are left for object to fly at elevated altitude
        private int ZmianaKursuTikCount = 0;
        // Distance of approach which is assumed as hazardous
        protected double HazadrousDist = 0.5d;
        // Objects speed
        protected int predkosc = 0;
        // Objects position
        private double x,y,z;
        // An angle at which object lands and starts as well as its flight altidute
        protected double kat, przelot;
        private double a_funkcja=0,b_funckja=0,kat_lotu=0,odl_ladowania=0;
        public double X { get => x; protected set=>x=value; }
        public double Y { get => y; protected set => y = value; }
        // Airfields at which the object starts and ends
        protected Lotnisko _Start=null, _Finish=null;

        /// <summary>
        /// A constructor of flying object
        /// </summary>
        /// <param name="lotniska">Airfield list</param>
        /// <param name="_kat">Angle of flight at start and end</param>
        /// <param name="_przelot">Flight altitude at which the flying object will aim to stay</param>
        public ObjektLatajacy(List<Lotnisko> lotniska,double _kat,double _przelot)
        {
            _Start=LosujLotnisko(lotniska);
            X = _Start.X;
            Y = _Start.Y;
            kat=Math.Round(Math.PI*_kat/180,3);
            przelot=_przelot;
            odl_ladowania=przelot*Math.Tan(kat)*100;
            z = 0;
<<<<<<< HEAD
            do
            {
               _Finish = LosujLotnisko(lotniska);
            } while (OdlLotniska() < 2 * odl_ladowania);
            funkcja();
=======
            //do
            //{
            //    _Finish = LosujLotnisko(lotniska);
            //} while (OdlLotniska() < 2 * odl_ladowania);
            //funkcja();
>>>>>>> parent of b007771... pozmieniano troche konstruktory , zlokalizowano blad z wypisywaniem
        }

        /// <summary>
        /// Randomly selects airfield
        /// </summary>
        /// <param name="lotniska">Airfield list</param>
        /// <returns>Randomly chosen airfield</returns>
        protected  Lotnisko LosujLotnisko(List<Lotnisko> lotniska)
        {
            Random random = new Random();
            int i=0;
            do
            {
                i = random.Next(lotniska.Count());
                Thread.Sleep(10);

            } while (this._Start == lotniska[i]);
            Console.WriteLine(i);
            return lotniska[i] ;
        }
        
        /// <summary>
        /// Function for managing flight from start to end
        /// </summary>
        public void Run()
        {
            bool Czy_wystartowal = false;
            if (z < przelot && Czy_wystartowal==false)
                Start();
            else if (z == przelot && OdlodLadowania()==false)
            {
                Czy_wystartowal = true;
                Lot();
            } 
            else if(Czy_wystartowal==true && OdlodLadowania()==true)
                Finish();

        }

        /// <summary>
        /// Function that runs as the flying object is at its flight altitude
        /// </summary>
        private void funkcja()
        {
            try
            {

                this.a_funkcja =(double) (_Start.Y - _Finish.Y) / (double)(_Start.X - _Finish.X);
            }
            catch (DivideByZeroException )
            {

                this.a_funkcja = 0d;
            }    
            this.b_funckja= (double)_Start.Y-a_funkcja* (double)_Start.X;
            this.kat_lotu=Math.Atan(a_funkcja*(Math.PI/180));//calculates in radians
        }

        /// <summary>
        /// The same as Transform() but has shorter name
        /// </summary>
        private void Lot()
        {
                Transform();
        }

        /// <summary>
        /// Calculates distance from starting point to the end
        /// </summary>
        /// <returns>Distance from starting point to the end</returns>
        private double OdlLotniska()
        {
            return Math.Round(Math.Sqrt(Math.Pow(_Start.X-_Finish.X,2)+Math.Pow(_Start.Y-_Finish.Y,2)),3)*100;
        }

        /// <summary>
        /// Function that checks distance from landing
        /// </summary>
        /// <returns>Returns true if the remaining distance is less than previously set landing distance, otherwise it returns false</returns>
        private bool OdlodLadowania()
        {
            if(Math.Sqrt(Math.Pow(this.x-_Finish.X,2)+Math.Pow(this.y-_Finish.Y,2))<odl_ladowania)
                return true;
            return false;
        }

        /// <summary>
        /// Function that is responsible for updating flying object variables
        /// </summary>
        private void Transform()
        {
            if (ZmianaKursuTikCount > 0)
            {
                ZmianaKursuTikCount--;
                if (ZmianaKursuTikCount == 0)
                    z -= 0.6d;
            }
<<<<<<< HEAD
                double dx=predkosc*20*Math.Cos(kat_lotu)/1000;
                double dy=predkosc*20*Math.Sin(kat_lotu)/1000;
            if (_Start.X < _Finish.X)
                x += dx;
            else
                x -= dx;
            if (_Start.Y < _Finish.Y)
                y += dy;
            else
                y -= dy;
=======
                double dx=predkosc*20*Math.Cos(kat_lotu);
                double dy=predkosc*20*Math.Sin(kat_lotu);
                if(_Start.X<_Finish.X)
                    x+=dx;
                else
                    x-=dx;
                if(_Start.Y<_Finish.Y)
                    y+=dy;
                else
                    y-=dy;
>>>>>>> parent of b007771... pozmieniano troche konstruktory , zlokalizowano blad z wypisywaniem
        }

        /// <summary>
        /// A method for predicting future position without changing object position
        /// </summary>
        /// /// <param name="tup">Position from which you'll get new predicted one</param>
        /// <returns>Position after transform</returns>
        private Tuple<int,int> TransformRet(Tuple<int, int> tup)
        {
            double dx = predkosc * 20 * Math.Cos(2*Math.PI-kat_lotu);
            double dy = predkosc * 20 * Math.Sin(kat_lotu);
            // position it returns
            double xRet, yRet;
            if (_Start.X < _Finish.X)
                 xRet = x + dx;
            else
                xRet = x - dx;
            if (_Start.Y < _Finish.Y)
                yRet = y + dy;
            else
                yRet = y - dy;
            return new Tuple<int, int>((int)xRet, (int)yRet);
        }

        /// <summary>
        /// Gives predicted position 3 ticks in the future
        /// </summary>
        /// <param name="objekt">Flying object of which future position we seek</param>
        /// <returns>Predicted position</returns>
        public Tuple<int,int> Przewidzpozycje()
        {
            //za 3 tiki
            Tuple<int, int> position = new Tuple<int, int>((int)this.x, (int)this.y);
            for(int i = 0; i < 3 ; i++ ) { position = TransformRet(position); }
            return position;
        }

        /// <summary>
        /// Reacts to approach in 3 tics
        /// </summary>
        /// <param name="flying">Flying object list</param>
        public void Zblizenie(LinkedList<ObjektLatajacy> flying)
        {
            double _x = this.Przewidzpozycje().Item1;
            double _y = this.Przewidzpozycje().Item2;

            //Emergency course change
            foreach (ObjektLatajacy avio in flying)
            {
                //So it doesn't check itself
                if (avio != this)
                {
                    double distance = Math.Sqrt(Math.Pow(Math.Sqrt(Math.Pow(_x - avio.Przewidzpozycje().Item1, 2) + Math.Pow(_y - avio.Przewidzpozycje().Item2, 2)), 2) + Math.Pow(this.z - avio.z, 2));
                    if (distance < HazadrousDist)
                        Jakzmienickurs( avio, true );
                }
            }
        }

        /// <summary>
        /// Changing a course of flight by getting higher
        /// </summary>
        /// <param name="avio">The object with which the approach is predicted</param>
        /// <param name="choice">True means chnging a course of object that called the function, false changess course of an object with which the approach has been predisted</param>
        public void Jakzmienickurs(ObjektLatajacy avio, bool choice)
        {
            if(choice)
            {
                this.z += 0.6d;
                ZmianaKursuTikCount = 5;
            }
            else
            {
                avio.z += 0.6d;
                avio.ZmianaKursuTikCount = 5;
            }

        }

        /// <summary>
        /// Function called at the start of flight
        /// </summary>
        private  void Start()//tick 20 s
        {
            double time =20;//s
            double skos=predkosc*time;
            double changewys=Math.Round(Math.Sin(kat)*skos);
            z+=changewys;
            Transform();
            
        }

        /// <summary>
        /// Function called at the end of flight
        /// </summary>
        private void Finish()
        {
            double time =20;//s
            double skos=predkosc*time;
            double changewys=Math.Round(Math.Sin(kat)*skos);
            z-=changewys;
            Transform();
        }
    }
}
