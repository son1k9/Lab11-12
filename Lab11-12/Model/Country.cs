namespace Lab11_12
{
    class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

        public Country() { }

        public Country(int id, string name, string code)
        {
            CountryId = id;
            Name = name;
            Code = code;
        }

        public Country Copy()
        {
            return new Country(CountryId, Name, Code);
        }
    }
}
