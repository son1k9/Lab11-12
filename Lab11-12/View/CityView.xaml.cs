using Lab11_12.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Lab11_12.Model;

namespace Lab11_12.View
{
    /// <summary>
    /// Interaction logic for CityView.xaml
    /// </summary>
    public partial class CityView : Window
    {
        public CityView()
        {
            InitializeComponent();

            List<Country> countries = new List<Country>();
            ObservableCollection<Country> countries1 = new CountryViewModel().Countries;
            foreach (Country country in countries1)
            {
                countries.Add(country);
            }

            ObservableCollection<City> cities = new CityViewModel().Cities;
            ObservableCollection<CityCountry> citiesWithCountries = new ObservableCollection<CityCountry>();

            foreach(City city in cities) 
            {
                Country? country = countries.Find(x => x.CountryId == city.CountryId);
                citiesWithCountries.Add(new CityCountry(city.CityId, city.Name, country.Name));
            }

            lvCities.ItemsSource = citiesWithCountries;
        }

        public CityView(Window window):this()
        {
            Owner = window;
        }
    }
}
