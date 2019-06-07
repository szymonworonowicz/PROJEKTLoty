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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROJEKTLoty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Start start;
        public MainWindow()
        {

            InitializeComponent();
            start = new Start();
            
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            start.start = true;
            start.Run();
            start.start = false;
            Console.WriteLine("1");
        }

        private void Left_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Right_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void Stop_Click (object sender ,RoutedEventArgs e)
        {
            start.start = false;
        }
    }
}
