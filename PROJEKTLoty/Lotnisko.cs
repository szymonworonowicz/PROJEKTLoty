﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PROJEKTLoty
{
    class Lotnisko
    {
        private int x;
        public int X
        {
            get
            {
                return x;
            }
            private set
            {
                x = value;
            }
        }
        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            private set
            {
                y = value;
            }
        }
        public string nazwa;
        public Brush kolor = Brushes.Purple;//kolor znaczka
        public Lotnisko(int _x,int _y,string _nazwa)
        {
            this.X = _x;
            this.Y = _y;
            this.nazwa = _nazwa;
        }
        public Lotnisko()
        {

        }
        public Lotnisko(Lotnisko lotnisko)
        {

        }
    }
}