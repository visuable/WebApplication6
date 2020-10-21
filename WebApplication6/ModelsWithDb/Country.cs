using System.Collections.Generic;

namespace WebApplication6.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
