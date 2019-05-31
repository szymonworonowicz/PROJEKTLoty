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
        Grid DynamicGrid = new Grid();
        public MainWindow()
        {
            InitializeComponent();
            DynamicGrid.Width=1000;
            DynamicGrid.Height=800;
            DynamicGrid.HorizontalAlignment=HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment=VerticalAlignment.Top;
            DynamicGrid.ShowGridLines=true;
            DynamicGrid.Background=new SolidColorBrush(Colors.Black);            
            //Create Columns
            for(int i=0;i<100;i++)
                {
                    ColumnDefinition column = new  ColumnDefinition();
                    DynamicGrid.ColumnDefinitions.Add(column);                
                }
            //Create Rows
            for (int i = 0; i < 100; i++)
            {
                RowDefinition row = new RowDefinition();
                DynamicGrid.RowDefinitions.Add(row);
            }
            this.Content = DynamicGrid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
