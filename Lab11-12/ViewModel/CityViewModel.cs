using Lab11_12.Model;
using Lab11_12.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Lab11_12.ViewModel
{
    class CityViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<City> Cities { get; } = new ObservableCollection<City>();
        private ObservableCollection<CityCountry> _citiesWithCountries;
        public ObservableCollection<CityCountry> CitiesWithCountries
        {
            get { return _citiesWithCountries; }
            set
            {
                _citiesWithCountries = value;
                OnPropertyChanged(nameof(CitiesWithCountries));
            }
        }
        public ObservableCollection<Country> Countries = CountryViewModel.Countries;

        private CityCountry? _selectedCityCountry;
        public CityCountry? SelectedCityCountry
        {
            get { return _selectedCityCountry; }
            set
            {
                _selectedCityCountry = value;
                OnPropertyChanged(nameof(SelectedCityCountry));
            }
        }

        static CityViewModel()
        {
            Cities.Add(new City(1, "Владимир", 1));
            Cities.Add(new City(2, "Лондон", 2));
            Cities.Add(new City(3, "Сидней", 3));
            Cities.Add(new City(4, "Москва", 1));
        }

        public CityViewModel() { CitiesWithCountries = GetCountries(); }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand? _addCity;
        public RelayCommand AddCity
        {
            get
            {
                return _addCity ??= new RelayCommand((obj) =>
                {
                    NewCityWindow newCountryWindow = new NewCityWindow()
                    {
                        Title = "Новый город",
                        Owner = Application.Current.MainWindow
                    };

                    int id = MaxId() + 1;
                    CityCountry cityCountry = new CityCountry()
                    {
                        Id = id
                    };

                    newCountryWindow.DataContext = cityCountry;
                    newCountryWindow.cbCity.ItemsSource = Countries;

                    if (newCountryWindow.ShowDialog() == true)
                    {
                        Country country = (Country)newCountryWindow.cbCity.SelectedValue;
                        if (country == null)
                        {
                            MessageBox.Show("Страна не была указана", "Ошибка", MessageBoxButton.OK);
                            return;
                        }

                        cityCountry.Country = country.Name;
                        Cities.Add(new City(cityCountry));
                        CitiesWithCountries = GetCountries();
                    }
                });
            }
        }

        private RelayCommand? _editCity;
        public RelayCommand EditCity
        {
            get
            {
                return _editCity ??= new RelayCommand((obj) =>
                {
                    CityCountry cityCountry = SelectedCityCountry!;

                    NewCityWindow newCountryWindow = new NewCityWindow()
                    {
                        Title = "Редактирование города",
                        Owner = Application.Current.MainWindow
                    };

                    CityCountry cityCountryCopy = new CityCountry(cityCountry);
                    newCountryWindow.DataContext = cityCountryCopy;
                    newCountryWindow.cbCity.ItemsSource = Countries;
                    newCountryWindow.cbCity.Text = cityCountryCopy.Country; //Try with SelectedValue

                    if (newCountryWindow.ShowDialog() == true)
                    {
                        Country country = (Country)newCountryWindow.cbCity.SelectedValue;
                        City city = Cities.ToList().Find(c => c.CityId == cityCountryCopy.Id);
                        city.Name = cityCountryCopy.Name;
                        city.CountryId = country.CountryId;
                        CitiesWithCountries = GetCountries();
                    }
                }, (obj) => SelectedCityCountry != null);
            }
        }

        private RelayCommand? _deleteCity;
        public RelayCommand DeleteCity
        {
            get
            {
                return _deleteCity ??= new RelayCommand((obj) =>
                {
                    CityCountry cityCountry = SelectedCityCountry!;

                    var result = MessageBox.Show($"Удалить данные по городу {cityCountry.Name}", "Предупреждение", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        City city = Cities.ToList().Find(c => c.CityId == cityCountry.Id);
                        Cities.Remove(city);
                        CitiesWithCountries = GetCountries();
                    }
                });
            }
        }

        ObservableCollection<CityCountry> GetCountries()
        {
            ObservableCollection<CityCountry> cityCountries = new ObservableCollection<CityCountry>();
            foreach (City city in Cities)
            {
                CityCountry cityCountry = new CityCountry()
                {
                    Id = city.CityId,
                    Name = city.Name,
                    Country = Countries.ToList().Find(x=>x.CountryId==city.CountryId).Name
                };
                cityCountries.Add(cityCountry);
            }
            return cityCountries;
        }

        public int MaxId()
        {
            int id = 0;
            foreach (City city in Cities)
            {
                if (city.CityId > id)
                {
                    id = city.CityId;
                }
            }
            return id;
        }
    }
}
