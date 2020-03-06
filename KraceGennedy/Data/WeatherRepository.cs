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
    }
}
