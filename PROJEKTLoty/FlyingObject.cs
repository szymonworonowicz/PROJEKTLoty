using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    /// <summary>
    /// Anbstact class of FlyingObject 
    /// </summary>
    public abstract class FlyingObject
    {
        /// <summary>
        ///  A wway to count how many tics therre are left for object to fly at elevated altitude
        /// </summary>
        public int ChangeCourseTikCount = 0;
        /// <summary>
        /// Distance of approach which is assumed as hazardous
        /// </summary>
        protected double HazadrousDist = 0.5d;
        private static int indexer = 1;
        /// <summary>
        /// object index
        /// </summary>
        public int index = 0;
        /// <summary>
        /// Objects speed
        /// </summary>
        protected int speed = 0;
        /// <summary>
        /// Objects position
        /// </summary>
        private double x,y,z;
        /// <summary>
        /// An angle at which object lands and starts as well as its flight altidute
        /// </summary>
        protected double degree;
        /// <summary>
        /// max flight altitude
        /// </summary>
        protected double passage;
        /// <summary>
        /// variable indicating whether the object started if true -started
        /// </summary>
        private bool Is_started = false;
        /// <summary>
        /// a and b from the linear function y = ax + b between the start and end Airfields and angle from this function
        /// </summary>
        private double a_function = 0, b_function = 0, flight_degree = 0;
        /// <summary>
        /// the minimum distance at which a flying object can discharge
        /// </summary>
        private double land_distance;
        /// <value>x value</value>
        public double X { get => x; protected set=>x=value; }
        /// <value>y value</value>
        public double Y { get => y; protected set => y = value; }
        /// <value>z value</value>
        public double Z { get => z; set => z = value; }
        /// <summary>
        ///  Airfields at which the object starts and ends
        /// </summary>
        public Airport _Start=null, _Finish=null;

        /// <summary>
        /// A constructor of flying object
        /// </summary>
        /// <param name="_predkosc">Flying object speed</param>
        /// <param name="_kat">Angle of flight at start and end</param>
        /// <param name="_przelot">Flight altitude at which the flying object will aim to stay</param>
        public FlyingObject(double _kat,double _przelot,int _predkosc)
        {
            _Start = LosujLotnisko(Main.Aircrafts);
            X = _Start.X;
            Y = _Start.Y;
            speed = _predkosc;
            degree=Math.Round(Math.PI*_kat/180,3);//change to radian
            passage=_przelot;
            land_distance=passage*Math.Tan(degree)/10000;
            z = 0;
            _Finish = LosujLotnisko(Main.Aircrafts);
            funkcja();
            index = indexer;
            indexer++;
        }
        /// <summary>
        /// Randomly selects airfield
        /// </summary>
        /// <param name="lotniska">Airfield list</param>
        /// <returns>Randomly chosen airfield</returns>
        protected Airport LosujLotnisko(List<Airport> lotniska)
        {
            Random random = new Random();
            int i=0;
            do
            {
                i = random.Next(lotniska.Count());
                Thread.Sleep(10);

            } while (this._Start == lotniska[i]);
            return lotniska[i] ;
        }
        /// <summary>
        /// Function for managing flight from start to end
        /// </summary>
        public void Run()
        {
            Zblizenie();
            if (z < passage && Is_started == false)
                Start();
            else if (OdlodLadowania()==false)
            {
                Is_started = true;
                Transform();
            }
             
            else if( OdlodLadowania()==true)
                Finish();
            
        }
        /// <summary>
        /// Function that runs as the flying object is at its flight altitude
        /// </summary>
        /// <exception cref="DivideByZeroException"/>
        private void funkcja()
        {
            try
            {
                this.a_function =(double) (_Start.Y - _Finish.Y) / (double)(_Start.X - _Finish.X);
            }
            catch (DivideByZeroException)
            {

                this.a_function = 0;
            }    
            this.b_function= (double)_Start.Y-a_function* (double)_Start.X;
            this.flight_degree=Math.Round(Math.Atan(a_function),3);//bo radiany
        }
        /// <summary>
        /// Calculates distance from starting point to the end
        /// </summary>
        /// <returns>Distance from starting point to the end</returns>
        private double OdlLotniska()
        {
            return Math.Round(Math.Sqrt(Math.Pow(_Start.X-_Finish.X,2)+Math.Pow(_Start.Y-_Finish.Y,2)),3)*100 ;
        }
        /// <summary>
        /// Function that checks distance from landing
        /// </summary>
        /// <returns>Returns true if the remaining distance is less than previously set landing distance, otherwise it returns false</returns>
        private bool OdlodLadowania()
        {
            if (Odlfinish() < land_distance) 
                return true;
            return false;
        }
        /// <summary>
        /// Function that checks distance from finish Aircraft
        /// </summary>
        /// <returns>Distance form object to finish aircraft</returns>
        private double Odlfinish()
        {
            return Math.Sqrt(Math.Pow(this.x - _Finish.X, 2) + Math.Pow(this.y - _Finish.Y, 2));
        }
        /// <summary>
        /// Function that is responsible for updating flying object variables
        /// </summary>
        private void Transform()
        {
            if (ChangeCourseTikCount > 0)
            {
                ChangeCourseTikCount--;
                if (ChangeCourseTikCount == 0)
                    z -= 60d;
            }
                double dx=speed*10*Math.Cos(flight_degree)/1000;
                double dy=speed*10*Math.Sin(flight_degree)/1000;
            if (_Start.X < _Finish.X)
                x += Math.Abs(dx);
            else
                x -= Math.Abs(dx);
            if (_Start.Y < _Finish.Y)
                y += Math.Abs(dy);
            else
                y -= Math.Abs(dy);
        }

        /// <summary>
        /// A method for predicting future position without changing object position
        /// </summary>
        /// /// <param name="tup">Position from which you'll get new predicted one</param>
        /// <returns>Position after transform</returns>
        private Tuple<int,int> TransformRet(Tuple<int, int> tup)
        {
            double dx = speed * 10 * Math.Cos(flight_degree);
            double dy = speed * 10 * Math.Sin(flight_degree);
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
        /// <returns> Throw CrushException when object cam colides</returns>
        public void Zblizenie()
        {
            double _x = this.Przewidzpozycje().Item1;
            double _y = this.Przewidzpozycje().Item2;

            //zmiana awaryjna kursu
            foreach (FlyingObject avio in Main.flying)
            {
                //żeby samego siebie nie liczyło
                if (avio != this)
                {
                    double distance = Math.Sqrt(Math.Pow(Math.Sqrt(Math.Pow(_x - avio.Przewidzpozycje().Item1, 2) + Math.Pow(_y - avio.Przewidzpozycje().Item2, 2)), 2) + Math.Pow(this.z - avio.z, 2));
                    if (distance < HazadrousDist)
                        throw new CrushException(this, avio);
                }
            }
        }
        /// <summary>
        /// Function called at the start of flight
        /// </summary>
        private void Start()//tick 10 s
        {
            double time =10;//s
            double skos=speed*time;
            double changewys=Math.Round(Math.Sin(degree)*skos);
            z+=changewys;
            if (z  > passage)
                z = passage;
            Transform();
            
        }
        /// <summary>
        /// Function called at the end of flight
        /// </summary>
        private void Finish()
        {
            double time =10;//s
            double skos=speed*time;
            double changewys=Math.Round(Math.Sin(degree)*skos);
            if (z < 0)
            {
                z = 0;
                return;
            }
            else if (Odlfinish() < 8)
            {
                Is_started = false;
                x = _Finish.X;
                y = _Finish.Y;
                z = 0;
                _Start = _Finish;
                _Finish = LosujLotnisko(Main.Aircrafts);
                funkcja();

            }
            z -= changewys;
            if (Odlfinish()>1d)
                Transform();
            
        }
        /// <summary>
        /// text representation of the object
        /// </summary>
        /// <return>otext representation of the object</return>
        public override string ToString()
        {
            return "[ "+index+" ] from" + _Start.ToString() + " to " + _Finish.ToString();
        }
        /// <summary>
        /// return Colour of an object  marker
        /// </summary>
        /// <return> marker color</return>
        public virtual SolidColorBrush ReturnColor()
        {
            return  Brushes.Red;
        }
        
    }
}
