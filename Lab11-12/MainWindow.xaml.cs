﻿using Lab11_12.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab11_12
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

        private void Countries_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CountryView(this);
            window.Show();
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CityView(this);
            window.Show();
        }
    }
}