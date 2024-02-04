using Lab11_12.ViewModel;
using System.Windows;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for CountryView.xaml
    /// </summary>
    public partial class CountryView : Window
    {
        CountryViewModel _countryViewModel = new CountryViewModel();

        public CountryView()
        {
            InitializeComponent();
            DataContext = _countryViewModel;
        }
    }
}
