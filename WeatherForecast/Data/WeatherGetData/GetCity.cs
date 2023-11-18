namespace WeatherForecast.Data.WeatherGetData
{
    public class GetCity
    {
        private readonly ApplicationDbContext? _db;
        public GetCity(ApplicationDbContext db)
        {
            _db = db;
        }
        public int GetCityId(string city, string country)
        {

            var CityFromDB = _db.Cities.FirstOrDefault(c => c.Name == city & c.Country == country.ToUpper());
            if (CityFromDB == null)
            {
                return 0;
            }
            else
            {
                return CityFromDB.Id;
            }
        }
    }
}
