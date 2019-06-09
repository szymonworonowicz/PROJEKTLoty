﻿using System;
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
    /// Main program Window 
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main class object
        /// </summary>
        public Main start;
        /// <summary>
        /// MainWindow constructor
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();
            start = new Main();
            
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            start.Run();
        }

        private void Left_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Right_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void Stop_Click (object sender ,RoutedEventArgs e)
        {
            Legend win = new Legend();
            win.ShowDialog();
        }
    }
}
