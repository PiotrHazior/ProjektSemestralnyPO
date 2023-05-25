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

namespace ProjectCarRentalPH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmployeeMenu(object sender, RoutedEventArgs e)
        {
            EmployeeMenu objEmployeeMenu = new EmployeeMenu();
            this.Visibility = Visibility.Hidden;
            objEmployeeMenu.Show();
        }

        private void CustomerMenu(object sender, RoutedEventArgs e)
        {
            CustomerMenu objCustomerMenu = new CustomerMenu();
            this.Visibility = Visibility.Hidden;
            objCustomerMenu.Show();
        }
    }
}
