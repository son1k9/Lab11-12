using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab11_12.Model;

namespace Lab11_12.ViewModel
{
    class CountryViewModel
    {
        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();

        public CountryViewModel()
        {
            Countries.Add(new Country(1, "Россия", "RU"));
            Countries.Add(new Country(2, "Великобритания", "UK"));
            Countries.Add(new Country(3, "Австралия", "AU"));
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

}
