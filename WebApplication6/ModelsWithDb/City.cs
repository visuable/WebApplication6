namespace WebApplication6.Models
{
    public class City
    {
        public int CityId { get; set; }
        public int Population { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}
