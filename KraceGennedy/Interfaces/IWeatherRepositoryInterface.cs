﻿using KraceGennedy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Interfaces
{
    public interface IWeatherRepositoryInterface
    {
        public void StoreWeatherData(WeatherInfo weatherInfo);
        
        public List<WeatherInfo> GetWeatherData();
        public List<WeatherInfo> GetWeatherDataByCityID(int cityID);
        public WeatherInfo GetWeatherDataByCityIDAndDate(int cityID, DateTime startDate);
    }
}
