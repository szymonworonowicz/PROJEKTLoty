using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROJEKTLoty
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObjektLatajacy first = null;
        ObjektLatajacy second = null;
        public Window1(ObjektLatajacy a, ObjektLatajacy b)
        {
            InitializeComponent();
            first = a;
            second = b;
            
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            ALt1.Text = first.ToString();
        }

        private void Button2_MouseMove(object sender, MouseEventArgs e)
        {
            ALt1.Text = second.ToString();
        }

        private void Button1_MouseLeave(object sender, MouseEventArgs e)
        {
            ALt1.Text = null;
        }
        private void Button2_MouseLeave(object sender, MouseEventArgs e)
        {
            ALt1.Text = null;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            first.Z += 0.6d;
            first.ZmianaKursuTikCount = 5;
            this.Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            second.Z += 0.6d;
            second.ZmianaKursuTikCount = 5;
            this.Close();
        }
    }
}
