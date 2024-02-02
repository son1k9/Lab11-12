using Lab11_12.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.ViewModel
{
    class CityViewModel
    {
        public ObservableCollection<City> Cities { get; set; } = new ObservableCollection<City>();

        public CityViewModel() 
        {
            Cities.Add(new City(1, "Владимир", 1));
            Cities.Add(new City(2, "Лондон", 2));
            Cities.Add(new City(3, "Сидней", 3));
            Cities.Add(new City(4, "Москва", 1));
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
