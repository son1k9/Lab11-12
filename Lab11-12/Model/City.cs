using Lab11_12.ViewModel;

namespace Lab11_12.Model;

class City
{
    public int CityId { get; set; }
    public string Name { get; set; }

    public int CountryId { get; set; }

    public City(int id, string name, int countryId)
    {
        CityId = id;
        Name = name;
        CountryId = countryId;
    }

    public City(City city)
    {
        CityId = city.CityId;
        Name = city.Name;
        CountryId = city.CountryId;
    }

    public City(CityCountry cityCountry)
    {
        int id = CountryViewModel.Countries.ToList().Find(country => country.Name == cityCountry.Country).CountryId;

        CityId = cityCountry.Id;
        Name = cityCountry.Name;
        CountryId = id;
    }
}
