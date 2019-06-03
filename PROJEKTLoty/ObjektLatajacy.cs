using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    abstract class ObjektLatajacy
    {
        protected int  predkosc,odl;
        private double x,y,z;
        protected double kat, przelot;
        private double a_funkcja=0,b_funckja=0,kat_lotu=0,odl_ladowania=0;
        public double X { get => x; protected set=>x=value; }
        public double Y { get => y; protected set => y = value; }
        protected Lotnisko _Start=null, _Finish=null;
        public Brush kolor =null;//kolor znaczka
        public ObjektLatajacy(List<Lotnisko> lotniska,double _kat,int _przelot,  Brush _kolor)
        {
            _Start=LosujLotnisko(lotniska);
            this.kolor = _kolor;
            X = _Start.X;
            Y = _Start.Y;
            kat=Math.Round(_kat,3);
            przelot=_przelot;
            odl_ladowania=przelot*(1/Math.Tan(kat))*100;
            z = 0;
            do
            {
                _Finish = LosujLotnisko(lotniska);
            } while (OdlLotniska() > 2 * odl_ladowania);
            funkcja();
        }
        private  Lotnisko LosujLotnisko(List<Lotnisko> lotniska)
        {
            Random rand = new Random();
            int i=0;
            do
            {
                i = rand.Next(0, lotniska.Count );
            } while (_Start == lotniska[i]);
            return lotniska[i] ;
        }
        public void Run()//transform pozycji
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
            this.kat_lotu=Math.Atan(a_funkcja*(Math.PI/180));//bo radiany
        }
        private void Lot()
        {
                Transform();
        }
        private double OdlLotniska()
        {
            return Math.Round(Math.Sqrt(Math.Pow(_Start.X-_Finish.X,2)+Math.Pow(_Start.Y-_Finish.Y,2)))*100;
        }
        private bool OdlodLadowania()
        {
            if(Math.Sqrt(Math.Pow(this.x-_Finish.X,2)+Math.Pow(this.y-_Finish.Y,2))<odl_ladowania)
                return true;
            return false;
        }
        private void Transform()
        {
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
        public Tuple<int,int> Przewidzpozycje(ObjektLatajacy objekt)
        {
            //za 3 tiki
            Tuple<int, int> position = new Tuple<int, int>((int)objekt.x, (int)objekt.y);
            for(int i = 0; i < 3 ; i++ ) { position = TransformRet(position); }
            return position;
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
            z+=changewys;
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
