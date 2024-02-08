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

            lvCountries.ItemsSource = CountryViewModel.Countries;
        }

        public CountryView(Window window) : this()
        {
            Owner = window;
        }

         

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NewCountryWindow newCountryWindow = new NewCountryWindow()
            {
                Title = "Новая страна",
                Owner = this
            };

            int id = _countryViewModel.MaxId() + 1;
            Country country = new Country()
            {
                CountryId = id
            };
            newCountryWindow.DataContext = country;

            if (newCountryWindow.ShowDialog() == true)
                CountryViewModel.Countries.Add(country);
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Country? country = lvCountries.SelectedItem as Country;
            if (country is null)
            {
                MessageBox.Show("Необходимо выбрать страну для редактирования", "Предупреждение", MessageBoxButton.OK);
                return;
            }

            NewCountryWindow newCountryWindow = new NewCountryWindow()
            {
                Title = "Редактирование страны",
                Owner = this
            };

            Country countryCopy = country.Copy();
            newCountryWindow.DataContext = countryCopy;
            if (newCountryWindow.ShowDialog() == true)
            {
                country.Name = countryCopy.Name;
                country.Code = countryCopy.Code;
                lvCountries.ItemsSource = null;
                lvCountries.ItemsSource = CountryViewModel.Countries;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Country? country = lvCountries.SelectedItem as Country;
            if (country is null)
            {
                MessageBox.Show("Необходимо выбрать страну для удаления", "Предупреждение", MessageBoxButton.OK);
                return;
            }

            var result = MessageBox.Show($"Удалить данные по стране {country.Name}", "Предупреждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (CityViewModel.Cities.ToList().Find(x => x.CountryId == country.CountryId) == null)
                    CountryViewModel.Countries.Remove(country);
                else
                    MessageBox.Show("Нельзя удалить эту страну, пока на неё ссылаются города", "Ошибка", MessageBoxButton.OK);
            }
        }
    }
}
    