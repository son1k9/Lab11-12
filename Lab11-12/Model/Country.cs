using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12
{
    class Country
    {
        public int CountryId { get; set; }
        public string Name {  get; set; }
        public string Code { get; set; }

        public Country(int id, string name, string code)
        {
            CountryId = id;
            Name = name;
            Code = code;
        }
    }
}
