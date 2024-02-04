using System.ComponentModel;

namespace Lab11_12.Model
{
    class CityCountry : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _country = string.Empty;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
