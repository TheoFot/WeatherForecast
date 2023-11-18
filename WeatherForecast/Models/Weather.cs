
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models
{
    public class Weather
    {

        public Weather()
        { }
        public Weather(float temperature, float temp_min, float temp_max, City city, int clouds, string speedOfWind, DateTime sunrise,
            DateTime sunset, DateTime day)
        {

            Temperature = temperature;
            TemperatureMin = temp_min;
            Temperature_Max = temp_max;
            City = city;
            Clouds = clouds;
            SpeedOfWind = speedOfWind;
            SunRise = sunrise;
            SunSet = sunset;
            Day = day;
        }
        [Key]
        public int Id { get; set; }

        public float Temperature { get; set; }
        public float TemperatureMin { get; set; }
        public float Temperature_Max { get; set; }
        public int Clouds { get; set; }
        public DateTime SunRise { get; set; }
        public DateTime SunSet { get; set; }
        public DateTime Day { get; set; }
        public string SpeedOfWind { get; set; }

        public City City { get; set; }
        public int CitiId { get; set; }

    }
}
