using Lab11_12.Model;
using Lab11_12.View;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace Lab11_12.ViewModel;

class CountryViewModel : INotifyPropertyChanged
{
    public static ObservableCollection<Country> Countries { get; private set; } = new ObservableCollection<Country>();

    private Country? _selectedCountry;
    public Country? SelectedCountry
    {
        get { return _selectedCountry; }
        set
        {
            _selectedCountry = value;
            OnPropertyChanged(nameof(SelectedCountry));
        }
    }

    readonly static private string _path = "..\\..\\..\\ModelData\\Country.json";

    static private void LoadCountries()
    {
        try
        {
            string jsonCountries = File.ReadAllText(_path);
            var countries = JsonConvert.DeserializeObject<ObservableCollection<Country>>(jsonCountries);
            if (countries != null)
            {
                Countries = countries;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private static void SaveChanges()
    {
        try
        {
            string jsonCountries = JsonConvert.SerializeObject(Countries, Formatting.Indented);
            using StreamWriter file = File.CreateText(_path);
            file.Write(jsonCountries);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    static CountryViewModel()
    {
        LoadCountries();
    }

    public CountryViewModel() { }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private RelayCommand? _addCountry;
    public RelayCommand AddCountry
    {
        get
        {
            return _addCountry ??= new RelayCommand((obj) =>
            {
            NewCountryWindow newCountryWindow = new NewCountryWindow()
            {
                Title = "Новая страна",
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = Application.Current.MainWindow
            };

            int id = MaxId() + 1;
            Country country = new Country() 
            {
                CountryId = id
            };
            newCountryWindow.DataContext = country;

            if (newCountryWindow.ShowDialog() == true)
                Countries.Add(country);
                SaveChanges();
            });
        }
    }

    private RelayCommand? _editCountry;
    public RelayCommand EditCountry
    {
        get
        {
            return _editCountry ??= new RelayCommand((obj) =>
            {
                Country country = SelectedCountry!;

                NewCountryWindow newCountryWindow = new NewCountryWindow()
                {
                    Title = "Редактирование страны",
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = Application.Current.MainWindow
                };

                Country countryCopy = country.Copy();
                newCountryWindow.DataContext = countryCopy;
                if (newCountryWindow.ShowDialog() == true)
                {
                    country.Name = countryCopy.Name;
                    country.Code = countryCopy.Code;
                    SaveChanges();
                }
            }, (obj)=>SelectedCountry!=null);
        }
    }

    private RelayCommand? _deleteCountry;
    public RelayCommand DeleteCountry
    {
        get
        {
            return _deleteCountry ??= new RelayCommand((obj) =>
            {
                Country country = SelectedCountry!;

                var result = MessageBox.Show($"Удалить данные по стране {country.Name}", "Предупреждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (CityViewModel.Cities.ToList().Find(x => x.CountryId == country.CountryId) == null)
                    {
                        Countries.Remove(country);
                        SaveChanges();
                    }
                    else
                        MessageBox.Show("Нельзя удалить эту страну, пока на неё ссылаются города", "Ошибка", MessageBoxButton.OK);
                }
            }, (obj) => SelectedCountry != null);
        }
    }

    public int MaxId()
    {
        int id = 0;
        foreach (Country country in Countries)
        {
            if (country.CountryId > id)
            {
                id = country.CountryId;
            }
        }
        return id;
    }
}
