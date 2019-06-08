using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace PROJEKTLoty
{ 
    class Awionetka:ObjektLatajacy
    {
        protected const double _kat = 65;//degree
        protected const double _przelot = 5000;//m
        protected const int _predkosc = 84;//mps
        public Awionetka() : base(_kat,_przelot,_predkosc)
        {
            
        }
        public override string ToString()
        {
            return "Awionetka" + base.ToString();
        }
    }
}
