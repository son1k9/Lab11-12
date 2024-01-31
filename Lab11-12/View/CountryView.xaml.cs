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
using Lab11_12.ViewModel;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for CountryView.xaml
    /// </summary>
    public partial class CountryView : Window
    {
        public CountryView()
        {
            InitializeComponent();

            lvCountries.ItemsSource = new CountryViewModel().Countries;
        }

        public CountryView(Window window):this()
        {
            Owner = window;
        }
    }
}
