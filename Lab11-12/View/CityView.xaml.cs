using Lab11_12.Model;
using Lab11_12.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for CityView.xaml
    /// </summary>
    public partial class CityView : Window
    {
        CityViewModel _cityViewModel = new CityViewModel();

        public CityView()
        {
            InitializeComponent();
            DataContext = _cityViewModel;
        }
    }
}
