namespace Lab11_12.Model
{
    class CityCountry
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public CityCountry() { }

        public CityCountry(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }

        public CityCountry(CityCountry cityCountry)
        {
            Id = cityCountry.Id;
            Name = cityCountry.Name;
            Country = cityCountry.Country;
        }
    }
}
