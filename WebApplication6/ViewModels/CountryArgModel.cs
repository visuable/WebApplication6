using System.Collections.Generic;

namespace WebApplication6.ViewModels
{
    public class CountryArgModel
    {
        public string Code { get; set; }
        public List<CityArgModel> Cities { get; set; }
        public string Name { get; set; }
    }
}
