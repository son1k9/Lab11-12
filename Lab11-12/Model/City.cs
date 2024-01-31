using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Model
{
    class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int CountryId {  get; set; }

        public City(int id, string name, int countyId) 
        { 
            CityId = id;
            Name = name;
            CountryId = countyId;
        }
    }
}
