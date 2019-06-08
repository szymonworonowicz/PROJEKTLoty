using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROJEKTLoty
{
    class LandingException:Exception
    {
        public LandingException(FlyingObject e)
        {
            MainWindow window =(MainWindow)Application.Current.MainWindow;
            window.wynik.Text = e.GetType() + " wyladował i przyjmuje kolejny lot z " + e._Start.nazwa + " do " + e._Finish.nazwa;
        }
    }
}
