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
using System.Windows.Shapes;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for NewCityWindow.xaml
    /// </summary>
    public partial class NewCountryWindow : Window
    {
        public NewCountryWindow()
        {
            InitializeComponent();
        }

        void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}