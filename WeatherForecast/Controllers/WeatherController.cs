using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Data;
using WeatherForecast.Data.WeatherGetData;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;
        private readonly ApplicationDbContext _db;

        public WeatherController(WeatherService weatherService, ApplicationDbContext db)
        {
            _weatherService = weatherService;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetWeather(string city, string country)
        {
            Console.WriteLine("Get weather method is ok ");
            _weatherService.PostWeatherToDB(city, country);
            Weather weather = _db.Weather.Include(c => c.City)
                 .OrderByDescending(w => w.Id).FirstOrDefault();
            if (weather == null || (weather.City.Name != city && weather.City.Country != country))
            {
                ViewBag.Message = "This city does not exist or is entered incorrectly.";
                return View("Index");
            }
            return View("Index", weather);
        }

        public IActionResult GetArchive(string city, string country)
        {
            Console.WriteLine("Get weather archive method is ok ");

            City cityFromDb = _db.Cities.Include(w => w.Weathers)
                .FirstOrDefault(c => c.Name == city && c.Country == country);

            if (cityFromDb == null || cityFromDb.Weathers == null)
            {
                ViewBag.Massage = "There is no data for this city";
            }
            return View("Archive", cityFromDb);
        }
        public IActionResult Archive()
        {
            return View();
        }

    }
}
