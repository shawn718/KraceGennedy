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
            var res = new WeatherApiResponse();
            try {
                if (_signInManager.IsSignedIn(User))
                {
                    //Fetch Weather Data
                    res = await _weatherInterface.GetWeatherAsync("Kingston");
                    
                    //Need to store result in session
                    //Need to only fetch at the end of the 5 day cycle
                    //If session empty use database data

                    //populate weather info to store in db
                    WeatherInfo weatherInfo = new WeatherInfo();
                    weatherInfo.CityID = res.id;
                    weatherInfo.Day = DateTime.Now;
                    //res.weather.ForEach(x => {
                    //    weatherInfo.WeatherDesc = x.main + ": " + x.description;
                    //    return;
                    //    });
                    //fetch city id from db
                    var cityID = _userRepositoriesInterface.GetCities().Find(x => x.CityName == res.name).ID;
                    weatherInfo.CityID = cityID;
                    //Store Weather data
                    //_weatherRepositoryInterface.StoreWeatherData(weatherInfo);
                }

            }catch(Exception ex)
            {

                _logger.LogError("Error:" + ex.Message);
            }
            return View(res);
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
