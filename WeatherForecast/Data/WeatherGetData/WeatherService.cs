
using Newtonsoft.Json;
using WeatherForecast.Models;
using WeatherForecast.Data.WeatherDataJson;


namespace WeatherForecast.Data.WeatherGetData
{
    public class WeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public WeatherService(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }


        public string GetWeatherByRequest(string city, string country)

        {
            GetCity getCityId = new GetCity(_db);

            int id = getCityId.GetCityId(city, country);

            if (id == 0)
            {
                return "No";
            }
            HttpClient client = new HttpClient();
            string apikey = _configuration["ApiSettings:ApiKey"];

            HttpResponseMessage requesrresult = client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?id={id}&units=metric&appid={apikey}").Result;

            string Jsonweather = requesrresult.Content.ReadAsStringAsync().Result;
            return Jsonweather;
        }
        public static DateTime ConvertFromUnix(int unixTime)
        {
            System.DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTime).ToLocalTime();
            return dt;
        }
        public static DateTime ConvertFromUnixToDay(int unixTime)
        {
            System.DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTime).ToLocalTime();
            return dt;
        }
        public void PostWeatherToDB(string city, string country)
        {
            try
            {
                var weathers = JsonConvert.DeserializeObject<RootObject>(GetWeatherByRequest(city, country));

                //int idweather = 0;
                //if (_db.Weather.OrderByDescending(w=>w.Id).LastOrDefault() != null)
                //{
                //    idweather = _db.Weather.OrderByDescending(w=>w.Id).LastOrDefault().Id +1;
                //}

                City cityfromdb = _db.Cities.FirstOrDefault(c => c.Name == city & c.Country == country);

                double speedOfWind = weathers.wind.gust * 3.6;
                string Windsspeed = String.Format("{0:f2}", speedOfWind);

                DateTime sunRise = ConvertFromUnix(weathers.sys.sunrise);
                DateTime sunSet = ConvertFromUnix(weathers.sys.sunset);
                DateTime day = ConvertFromUnixToDay(weathers.dt);


                var weather = new Weather(weathers.main.temp, weathers.main.temp_min, weathers.main.temp_max, cityfromdb
                    , weathers.clouds.all, Windsspeed, sunRise, sunSet, day);
                WeatherToDB(weather);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");

            }

        }

        public void WeatherToDB(Weather weather)
        {
            _db.Weather.Add(weather);
            _db.SaveChanges();

        }

    }
}
