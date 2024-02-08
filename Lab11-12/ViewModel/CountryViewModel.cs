using System.Collections.ObjectModel;

namespace Lab11_12.ViewModel
{
    class CountryViewModel
    {
        public static ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();

        static CountryViewModel()
        {
            Countries.Add(new Country(1, "Россия", "RU"));
            Countries.Add(new Country(2, "Великобритания", "UK"));
            Countries.Add(new Country(3, "Австралия", "AU"));
        }

        public CountryViewModel() { }

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

}
