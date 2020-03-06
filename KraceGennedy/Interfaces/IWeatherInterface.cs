using KraceGennedy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Interfaces
{
    public interface IWeatherInterface
    {
        public Task<WeatherApiResponse> GetWeatherAsync(string q);
        
    }
}
