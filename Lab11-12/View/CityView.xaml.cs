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
        CountryViewModel _countryViewModel = new CountryViewModel();
        CityViewModel _cityViewModel = new CityViewModel();
        ObservableCollection<CityCountry> _citiesWithCountries = new ObservableCollection<CityCountry>();
        List<Country> countries;

        public CityView()
        {
            InitializeComponent();

            countries = _countryViewModel.Countries.ToList();

            foreach (City city in _cityViewModel.Cities)
            {
                Country country = countries.Find(x => x.CountryId == city.CountryId);
                _citiesWithCountries.Add(new CityCountry(city.CityId, city.Name, country.Name));
            }

            lvCities.ItemsSource = _citiesWithCountries;
        }

        public CityView(Window window) : this()
        {
            Owner = window;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NewCityWindow newCountryWindow = new NewCityWindow()
            {
                Title = "Новый город",
                Owner = this
            };

            int id = _cityViewModel.MaxId() + 1;
            CityCountry cityCountry = new CityCountry()
            {
                Id = id
            };

            newCountryWindow.DataContext = cityCountry;
            newCountryWindow.cbCity.ItemsSource = countries;

            if (newCountryWindow.ShowDialog() == true)
            {
                Country country = (Country)newCountryWindow.cbCity.SelectedValue;
                if (country == null)
                {
                    MessageBox.Show("Страна не была указана", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                
                cityCountry.Country = country.Name;
                _citiesWithCountries.Add(cityCountry);
                _cityViewModel.Cities.Add(new City(cityCountry));
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            CityCountry? cityCountry = lvCities.SelectedValue as CityCountry;
            if (cityCountry == null)
            {
                MessageBox.Show("Необходимо выбрать город для редактирования", "Предупреждение", MessageBoxButton.OK);
                return;
            }


            NewCityWindow newCountryWindow = new NewCityWindow()
            {
                Title = "Редактирование города",
                Owner = this
            };

            CityCountry cityCountryCopy = new CityCountry(cityCountry);
            newCountryWindow.DataContext = cityCountryCopy;
            newCountryWindow.cbCity.ItemsSource = countries;
            newCountryWindow.cbCity.Text = cityCountryCopy.Country; //Try with SelectedValue

            if (newCountryWindow.ShowDialog() == true)
            {
                Country country = (Country)newCountryWindow.cbCity.SelectedValue;
                cityCountry.Name = cityCountryCopy.Name;
                cityCountry.Country = country.Name;
                lvCities.ItemsSource = null;
                lvCities.ItemsSource = _citiesWithCountries;

                City city = _cityViewModel.Cities.ToList().Find(c => c.CityId == cityCountry.Id);
                city.Name = cityCountry.Name;
                city.CountryId = country.CountryId;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            CityCountry? cityCountry = lvCities.SelectedItem as CityCountry;
            if (cityCountry is null)
            {
                MessageBox.Show("Необходимо выбрать страну для удаления", "Предупреждение", MessageBoxButton.OK);
                return;
            }

            var result = MessageBox.Show($"Удалить данные по городу {cityCountry.Name}", "Предупреждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _citiesWithCountries.Remove(cityCountry);
                City city = _cityViewModel.Cities.ToList().Find(c => c.CityId == cityCountry.Id);
                _cityViewModel.Cities.Remove(city);
            }
        }
    }
}
