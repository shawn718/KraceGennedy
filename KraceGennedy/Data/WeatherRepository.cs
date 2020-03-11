using KraceGennedy.Interfaces;
using KraceGennedy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Data
{
    public class WeatherRepository : IWeatherRepositoryInterface
    {
        private readonly KraceGennedyContext _context;

        public WeatherRepository(KraceGennedyContext context)
        {
            _context = context;
        }

        public void StoreWeatherData(WeatherInfo weatherInfo)
        {
            _context.WeatherInfos.Add(weatherInfo);
            _context.SaveChanges();
        }

        public List<WeatherInfo> GetWeatherData()
        {
            var res = _context.WeatherInfos.ToList();

            return res;
        }

        public List<WeatherInfo> GetWeatherDataByCityID(int cityID)
        {
            List<WeatherInfo> weatherInfos = new List<WeatherInfo>();
            weatherInfos = _context.WeatherInfos.Where(x => x.CityID == cityID).ToList();

            return weatherInfos;
        }

        public WeatherInfo GetWeatherDataByCityIDAndDate(int cityID, DateTime startDate)
        {
            return _context.WeatherInfos
                           .Where(x => x.Day >= startDate && x.CityID == cityID)
                           .FirstOrDefault();
        }
    }
}
