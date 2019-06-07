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
        private int ZmianaKursuTikCount = 0;
        protected double HazadrousDist = 0.5d;
        protected int predkosc = 0;
        private double x,y,z;
        protected double kat, przelot;
        private bool Czy_wystartowal = false;
        private double a_funkcja=0,b_funckja=0,kat_lotu=0,odl_ladowania=0;
        public double X { get => x; protected set=>x=value; }
        public double Y { get => y; protected set => y = value; }
        protected Lotnisko _Start=null, _Finish=null;
        public ObjektLatajacy(List<Lotnisko> lotniska,double _kat,double _przelot,int _predkosc)
        {
            _Start=LosujLotnisko(lotniska);
            X = _Start.X;
            Y = _Start.Y;
            predkosc = _predkosc;
            kat=Math.Round(Math.PI*_kat/180,3);//change to radian
            przelot=_przelot;
            odl_ladowania=przelot*Math.Tan(kat);
            z = 0;
            //do
            //{
               _Finish = LosujLotnisko(lotniska);
            //} while (OdlLotniska() < 2 * odl_ladowania);
            funkcja();
        }
        protected  Lotnisko LosujLotnisko(List<Lotnisko> lotniska)
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
        
        public void Run()//transform pozycji
        {
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
        private void funkcja()//funkcja lotu gdy juz wlecial na przelot
        {
            try
            {
                this.a_funkcja =(double) (_Start.Y - _Finish.Y) / (double)(_Start.X - _Finish.X);
            }
            catch (DivideByZeroException)
            {

                this.a_funkcja = 0;
            }    
            this.b_funckja= (double)_Start.Y-a_funkcja* (double)_Start.X;
            this.kat_lotu=Math.Round(Math.Atan(a_funkcja),3);//bo radiany
        }
        private void Lot()
        {
                Transform();
        }
        private double OdlLotniska()
        {
            return Math.Round(Math.Sqrt(Math.Pow(_Start.X-_Finish.X,2)+Math.Pow(_Start.Y-_Finish.Y,2)),3)*100;
        }
        private bool OdlodLadowania()
        {
            if(Math.Sqrt(Math.Pow(this.x-_Finish.X,2)+Math.Pow(this.y-_Finish.Y,2))<odl_ladowania)
                return true;
            return false;
        }
        private void Transform()
        {
            if (ZmianaKursuTikCount > 0)
            {
                ZmianaKursuTikCount--;
                if (ZmianaKursuTikCount == 0)
                    z -= 0.6d;
            }
                double dx=predkosc*20*Math.Cos(kat_lotu)/1000;
                double dy=predkosc*20*Math.Sin(kat_lotu)/1000;
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
            double dx = predkosc * 20 * Math.Cos(kat_lotu);
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
        /// <param name="objekt">Flying object of which future position we seek and Yoda it sounds kind of like :-P</param>
        /// <returns>Predicted position</returns>
        public Tuple<int,int> Przewidzpozycje()
        {
            //za 3 tiki
            Tuple<int, int> position = new Tuple<int, int>((int)this.x, (int)this.y);
            for(int i = 0; i < 3 ; i++ ) { position = TransformRet(position); }
            return position;
        }

        /// <summary>
        /// Reaguje na zbliżenie które jast przewidziane na za 3 tiki
        /// </summary>
        /// <param name="flying">lista obiektów latających</param>
        public void Zblizenie(LinkedList<ObjektLatajacy> flying)
        {
            double _x = this.Przewidzpozycje().Item1;
            double _y = this.Przewidzpozycje().Item2;

            //zmiana awaryjna kursu
            foreach (ObjektLatajacy avio in flying)
            {
                //żeby samego siebie nie liczyło
                if (avio != this)
                {
                    double distance = Math.Sqrt(Math.Pow(Math.Sqrt(Math.Pow(_x - avio.Przewidzpozycje().Item1, 2) + Math.Pow(_y - avio.Przewidzpozycje().Item2, 2)), 2) + Math.Pow(this.z - avio.z, 2));
                    if (distance < HazadrousDist)
                        Jakzmienickurs( avio, true );
                }
            }
        }

        /// <summary>
        /// Zmiana kursu poprzez wzlot wyżej
        /// </summary>
        /// <param name="avio">Obiekt z którym przewidziane jest zbliżenie</param>
        /// <param name="choice">True to zmiana kursu obiektu wywołującego funkcję a false to zmiana kursu samolotym z którym zbliżenie jest przewidziane</param>
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
        private  void Start()//tick 20 s
        {
            double time =20;//s
            double skos=predkosc*time;
            double changewys=Math.Round(Math.Sin(kat)*skos);
            z+=changewys;
            if (z  > przelot)
                z = przelot;
            Transform();
            
        }
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
