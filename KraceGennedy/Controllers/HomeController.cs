using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KraceGennedy.Models;
using KraceGennedy.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using KraceGennedy.Static;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace KraceGennedy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherInterface _weatherInterface;
        private readonly IWeatherRepositoryInterface _weatherRepositoryInterface;

        public IUserRepositoriesInterface _userRepositoriesInterface;

        public SignInManager<IdentityUser> _signInManager { get; }

        public HomeController(ILogger<HomeController> logger, IWeatherInterface weatherInterface
            , IWeatherRepositoryInterface weatherRepositoryInterface, IUserRepositoriesInterface UserRepositoriesInterface
            , SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _weatherInterface = weatherInterface;
            _weatherRepositoryInterface = weatherRepositoryInterface;
            this._userRepositoriesInterface = UserRepositoriesInterface;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resApi = new WeatherApiResponse();
            try {
                if (_signInManager.IsSignedIn(User))
                {
                    var userEmail = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString(ApplicationVariables.SessionVariables.UserEmail));
                    var usersCityId = _userRepositoriesInterface.GetEmployeeByEmail(userEmail).CityID;
                    //Fetch Weather Data from db
                    var resDB = _weatherRepositoryInterface.GetWeatherDataByCityID(usersCityId);
                    //Fetch cities stored in database
                    var cities = _userRepositoriesInterface.GetCities();
                    var cityName = cities.Find(x => x.ID == usersCityId).CityName;
                    //Checks to see if there is weather data in db
                    if (resDB.Count > 0)
                    {
                        var todaysDate = DateTime.Now.Date;
                        var tommorrowsDate = DateTime.Now.AddDays(1).Date;
                        //checks to se if there is a record of weather data in db for today
                        var hasTodayWData = resDB.Find(x => x.Day.Date == todaysDate);
                        //checks to se if there is a record of weather data in db for the next day
                        var hasTomorrowsWData = resDB.Find(x => x.Day.Date == tommorrowsDate);
                        //if there is no data in db for today and tomorrow fetch data from api
                        if (hasTodayWData == null && hasTomorrowsWData == null)
                        {
                            //Fetch Weather Data from api
                            resApi = await _weatherInterface.GetWeatherAsync(cityName);
                            
                            //Need to store result in session & DB

                            //populate weather info to store in db
                            foreach (var wData in resApi.list)
                            {
                                WeatherInfo weatherInfo = new WeatherInfo();
                                weatherInfo.Day = Convert.ToDateTime(wData.dt_txt);
                                if (weatherInfo.Day.Hour == 6)
                                {
                                    weatherInfo.WeatherDesc = wData.weather[0].main + ": " + wData.weather[0].description;
                                    //fetch city id from db
                                    var cityID = cities.Find(x => x.CityName == resApi.city.name).ID;
                                    weatherInfo.CityID = cityID;
                                    //Store Weather data
                                    _weatherRepositoryInterface.StoreWeatherData(weatherInfo);
                                }

                            }

                        }
                        else
                        {
                            resApi.list = new List<List>();
                            //Use data from db
                            foreach (var item in resDB)
                            {
                                if(item.Day.Date >= todaysDate.Date)
                                {
                                    resApi.city = new City();
                                    resApi.city.name = cityName;
                                    List list = new List();
                                    list.dt_txt = item.Day.ToString();
                                    var strArr = item.WeatherDesc.Split(':');
                                    list.weather = new List<Weather>();
                                    Weather weather = new Weather();
                                    weather.main = strArr[0];
                                    weather.description = strArr[1];
                                    list.weather.Add(weather);
                                    resApi.list.Add(list);
                                }
                                
                            }
                            //await _weatherInterface.GetWeatherAsync("Kingston"); //temporay
                            //Need to only fetch at the end of the 5 day cycle
                            //If session empty use database data
                        }
                    }
                    else
                    {
                        //Fetch data from api
                        resApi = await _weatherInterface.GetWeatherAsync("Kingston");
                        //Need to store result in session & DB

                        //populate weather info to store in db
                        foreach (var wData in resApi.list)
                        {
                            WeatherInfo weatherInfo = new WeatherInfo();
                            weatherInfo.Day = Convert.ToDateTime(wData.dt_txt);
                            if (weatherInfo.Day.Hour == 6)
                            {
                                weatherInfo.WeatherDesc = wData.weather[0].main + ": " + wData.weather[0].description;
                                //fetch city id from db
                                var cityID = cities.Find(x => x.CityName == resApi.city.name).ID;
                                weatherInfo.CityID = cityID;
                                //Store Weather data
                                _weatherRepositoryInterface.StoreWeatherData(weatherInfo);
                            }

                        }

                    }

                }

            }catch(Exception ex)
            {

                _logger.LogError("Error:" + ex.Message);
            }
            return View(resApi);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
