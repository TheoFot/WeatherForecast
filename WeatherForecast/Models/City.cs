using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models
{
    public class City
    {
        public City()
        { }
        public City(int id, string name, string country)
        {
            this.Id = id;
            this.Name = name;
            this.Country = country;
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the city")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Only 2 letters")]
        public string Country { get; set; }

        public List<Weather> Weathers { get; set; } = new List<Weather>();



    }
}
