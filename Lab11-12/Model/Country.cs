using System.ComponentModel;

namespace Lab11_12.Model;

class Country : INotifyPropertyChanged
{
    private int _countryId;
    public int CountryId
    {
        get { return _countryId; }
        set
        {
            _countryId = value;
            OnPropertyChanged(nameof(CountryId));
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
    private string _code = string.Empty;
    public string Code
    {
        get { return _code; }
        set
        {
            _code = value;
            OnPropertyChanged(nameof(Code));
        }
    }

    public Country() { }

    public Country(int id, string name, string code)
    {
        CountryId = id;
        Name = name;
        Code = code;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Country Copy()
    {
        return new Country(CountryId, Name, Code);
    }
}
