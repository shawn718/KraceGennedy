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
        public SignInManager<IdentityUser> SignInManager { get; }

        public HomeController(ILogger<HomeController> logger, IWeatherInterface weatherInterface
            , IWeatherRepositoryInterface weatherRepositoryInterface, IUserRepositoriesInterface UserRepositoriesInterface
            , SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _weatherInterface = weatherInterface;
            _weatherRepositoryInterface = weatherRepositoryInterface;
            this._userRepositoriesInterface = UserRepositoriesInterface;
            this.SignInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var resApi = new WeatherApiResponse();
            var displayResApi = new WeatherApiResponse();
            try {
                if (SignInManager.IsSignedIn(User))
                {
                    var loggedInUser = HttpContext.Session.GetString(ApplicationVariables.SessionVariables.UserEmail);
                    List<string> listOfCities = new List<string>();
                    List<WeatherApiResponse> weatherApiResponsesList = new List<WeatherApiResponse>();
                    List<Employee> listOfEmployees = _userRepositoriesInterface.GetEmployees();
                    //Fetch cities stored in database
                    var cities = _userRepositoriesInterface.GetCities();

                    //populatelist of cities
                    if (listOfEmployees != null && listOfEmployees.Count > 0)
                    {
                        foreach (var emp in listOfEmployees)
                        {
                            listOfCities.Add(_userRepositoriesInterface.GetEmployeeByEmail(emp.Email).City.CityName);
                        }
                    }
                    
                    //checks if city list is empty
                    if(listOfCities != null && listOfEmployees.Count > 0)
                    {
                        List<string> cityDataFetched = new List<string>();
                        //populate list of weatherdata responses per city
                        foreach(var city in listOfCities)
                        {

                            //Fetch data from api
                            if (!cityDataFetched.Contains(city))
                            {
                                resApi = await _weatherInterface.GetWeatherAsync(city);
                                if (resApi.list != null)
                                {
                                    weatherApiResponsesList.Add(resApi);
                                    cityDataFetched.Add(city);
                                }

                            }
                            
                            
                            
                           
                        }
                    }

                    //checks if weatherlist is empty
                    if(weatherApiResponsesList != null && weatherApiResponsesList.Count > 0)
                    {
                        //populate weather data to be displayed for current users city
                        foreach(var emp in listOfEmployees)
                        {
                            if(emp.Email.ToLower().Trim() == loggedInUser.ToLower().Trim()) { 
                                foreach (var weather in weatherApiResponsesList)
                                {
                                    var cityID = cities.Where(x => x.CityName.Trim() == weather.city.name.Trim())
                                        .FirstOrDefault().ID;
                                    if (emp.CityID == cityID && emp.Email.ToLower().Trim() == loggedInUser.ToLower().Trim())
                                        {
                                            displayResApi.list = new List<List>();
                                            //Use data from db
                                            foreach (var item in weather.list)
                                            {
                                                if (Convert.ToDateTime(item.dt_txt).Date >= DateTime.Now.Date)
                                                {
                                                    displayResApi.city = new City();
                                                    displayResApi.city.name = weather.city.name;
                                                    List list = new List();
                                                    list.dt_txt = item.dt_txt;
                                                    list.weather = new List<Weather>();
                                                    Weather weatherForList = new Weather();
                                                    weatherForList.main = item.weather[0].main;
                                                    weatherForList.description = item.weather[0].description;
                                                    list.weather.Add(weatherForList);
                                                    displayResApi.list.Add(list);
                                                }

                                            }
                                            break;
                                    }
                                }
                                break;
                            }
                        }

                        foreach (var weather in weatherApiResponsesList)
                        {
                            var cityID = cities.Where(x => x.CityName.Trim() == weather.city.name.Trim())
                                .FirstOrDefault().ID;

                            //Fetch Weather Data from db
                            var resFromDB = _weatherRepositoryInterface.GetWeatherDataByCityID(cityID);
                            if(resFromDB != null && resFromDB.Count > 0)
                            {
                                var todaysDate = DateTime.Now.Date;
                                var tommorrowsDate = DateTime.Now.AddDays(1).Date;
                                //checks to se if there is a record of weather data in db for today
                                var hasTodayWData = resFromDB.Find(x => x.Day.Date == todaysDate);
                                //checks to se if there is a record of weather data in db for the next day
                                var hasTomorrowsWData = resFromDB.Find(x => x.Day.Date == tommorrowsDate);
                                //if there is no data in db for today and tomorrow fetch data from api
                                if (hasTodayWData == null && hasTomorrowsWData == null)
                                {
                                    //Fetch Weather Data from api
                                    resApi = await _weatherInterface.GetWeatherAsync(weather.city.name);

                                    //populate weather info to store in db
                                    foreach (var wData in resApi.list)
                                    {
                                        WeatherInfo weatherInfo = new WeatherInfo();
                                        weatherInfo.Day = Convert.ToDateTime(wData.dt_txt);
                                        if (weatherInfo.Day.Hour == 6)
                                        {
                                            weatherInfo.WeatherDesc = wData.weather[0].main + ": " + wData.weather[0].description;
                                            
                                            weatherInfo.CityID = cityID;
                                            //Store Weather data
                                            _weatherRepositoryInterface.StoreWeatherData(weatherInfo);
                                        }

                                    }

                                }
                                
                            }
                        }                     
                    }
                }

            }catch(Exception ex)
            {

                _logger.LogError("Error:" + ex.Message);
            }
            return View(displayResApi);
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
