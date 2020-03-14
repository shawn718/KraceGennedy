using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KraceGennedy.Interfaces;
using KraceGennedy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KraceGennedy.Controllers
{
    [Route("api/notification")]
    public class NotificationController : Controller
    {
        //Declare variables for interfaces, logger, dbcontext and repositories
        public IUserRepositoriesInterface _userRepositoriesInterface { get; }
        public IWeatherRepositoryInterface _weatherRepositoryInterface { get; }

        public NotificationController(IUserRepositoriesInterface UserRepositoriesInterface, IWeatherRepositoryInterface weatherRepositoryInterface)
        {
            this._userRepositoriesInterface = UserRepositoriesInterface;
            this._weatherRepositoryInterface = weatherRepositoryInterface;
        }
        // GET: api/<controller>
        [HttpPost]
        [Route("schedule")]
        [AllowAnonymous]
        public IEnumerable<string> GenerateSchedule()
        {
            try
            {
                //Fetch all Employees 
                var employees = _userRepositoriesInterface.GetEmployees();
                //Check db for todays schedule
                if(employees != null)
                {
                    //iniialize current date
                    var currentDate = DateTime.Now.Date;
                    //Figure out which day it is
                    var dayOfWeek = DateTime.Now.DayOfWeek.ToString();
                    //Carry out the respective action based on the day
                    switch (dayOfWeek)
                    {
                        case "Sunday":
                                    //Initialize counter
                                    int numOfDsays = 6;
                                    //loop through each employees
                                    foreach(var emp in employees) { 
                                        //start schedule check loop
                                        for(int i = 1; i <= numOfDsays;) {
                                            //check if employees hrs were already scheduled for this day
                                            var hasSchedule = _userRepositoriesInterface.
                                               GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                            //if user has no scheduled hrs for selected day generate schedule
                                            if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != "" 
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                            {
                                                Schedule schedule = new Schedule();
                                                schedule.Day = currentDate.ToString();
                                                schedule.EmployeeID = emp.EmployeeId;
                                                //Aquire weather data for users city for currentdate
                                                var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                        emp.CityID, currentDate);
                                                //determine schedule
                                                schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);
                                                //store schedule
                                                _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                            }
                                            //Checks if email was already sent
                                            var emailSent =_userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                            if (!emailSent) { 
                                                //send email
                                            }
                                            //Increment for loop
                                            i = i + 1;
                                            //move on to the next day
                                            currentDate = currentDate.AddDays(1);
                                        }
                                    }
                                    
                                    break;
                        case "Monday":
                            //Initialize counter
                             numOfDsays = 5;
                            //loop through each employees
                            foreach (var emp in employees)
                            {
                                //start schedule check loop
                                for (int i = 1; i <= numOfDsays;)
                                {
                                    //check if employees hrs were already scheduled for this day
                                    var hasSchedule = _userRepositoriesInterface.
                                       GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                    //if user has no scheduled hrs for selected day generate schedule
                                    if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != ""
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                    {
                                        Schedule schedule = new Schedule();
                                        schedule.Day = currentDate.ToString();
                                        schedule.EmployeeID = emp.EmployeeId;
                                        //Aquire weather data for users city for currentdate
                                        var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                emp.CityID, currentDate);
                                        //determine schedule
                                        schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);

                                        //store schedule
                                        _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                    }
                                    //Checks if email was already sent
                                    var emailSent = _userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                    if (!emailSent)
                                    {
                                        //send email
                                    }
                                    //Increment for loop
                                    i = i + 1;
                                    //move on to the next day
                                    currentDate = currentDate.AddDays(1);
                                }
                            }

                            break;
                        case "Tuesday":
                            //Initialize counter
                            numOfDsays = 4;
                            //loop through each employees
                            foreach (var emp in employees)
                            {
                                //start schedule check loop
                                for (int i = 1; i <= numOfDsays;)
                                {
                                    //check if employees hrs were already scheduled for this day
                                    var hasSchedule = _userRepositoriesInterface.
                                       GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                    //if user has no scheduled hrs for selected day generate schedule
                                    if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != ""
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                    {
                                        Schedule schedule = new Schedule();
                                        schedule.Day = currentDate.ToString();
                                        schedule.EmployeeID = emp.EmployeeId;
                                        //Aquire weather data for users city for currentdate
                                        var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                emp.CityID, currentDate);
                                        //determine schedule
                                        schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);
                                        _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                    }
                                    //Checks if email was already sent
                                    var emailSent = _userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                    if (!emailSent)
                                    {
                                        //send email
                                    }
                                    //Increment for loop
                                    i = i + 1;
                                    //move on to the next day
                                    currentDate = currentDate.AddDays(1);
                                }
                            }

                            break;
                        case "Wednesday":
                            //Initialize counter
                            numOfDsays = 3;
                            //loop through each employees
                            foreach (var emp in employees)
                            {
                                //start schedule check loop
                                for (int i = 1; i <= numOfDsays;)
                                {
                                    //check if employees hrs were already scheduled for this day
                                    var hasSchedule = _userRepositoriesInterface.
                                       GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                    //if user has no scheduled hrs for selected day generate schedule
                                    if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != ""
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                    {
                                        Schedule schedule = new Schedule();
                                        schedule.Day = currentDate.ToString();
                                        schedule.EmployeeID = emp.EmployeeId;
                                        //Aquire weather data for users city for currentdate
                                        var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                emp.CityID, currentDate);
                                        //determine schedule
                                        schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);
                                        _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                    }
                                    //Checks if email was already sent
                                    var emailSent = _userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                    if (!emailSent)
                                    {
                                        //send email
                                    }
                                    //Increment for loop
                                    i = i + 1;
                                    //move on to the next day
                                    currentDate = currentDate.AddDays(1);
                                }
                            }

                            break;
                        case "Thursday":
                            //Initialize counter
                            numOfDsays = 2;
                            //loop through each employees
                            foreach (var emp in employees)
                            {
                                //start schedule check loop
                                for (int i = 1; i <= numOfDsays;)
                                {
                                    //check if employees hrs were already scheduled for this day
                                    var hasSchedule = _userRepositoriesInterface.
                                       GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                    //if user has no scheduled hrs for selected day generate schedule
                                    if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != ""
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                    {
                                        Schedule schedule = new Schedule();
                                        schedule.Day = currentDate.ToString();
                                        schedule.EmployeeID = emp.EmployeeId;
                                        //Aquire weather data for users city for currentdate
                                        var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                emp.CityID, currentDate);
                                        //determine schedule
                                        schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);
                                        _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                    }
                                    //Checks if email was already sent
                                    var emailSent = _userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                    if (!emailSent)
                                    {
                                        //send email
                                    }
                                    //Increment for loop
                                    i = i + 1;
                                    //move on to the next day
                                    currentDate = currentDate.AddDays(1);
                                }
                            }

                            break;
                        case "Friday":
                            //Initialize counter
                            numOfDsays = 1;
                            //loop through each employees
                            foreach (var emp in employees)
                            {
                                //start schedule check loop
                                for (int i = 1; i <= numOfDsays;)
                                {
                                    //check if employees hrs were already scheduled for this day
                                    var hasSchedule = _userRepositoriesInterface.
                                       GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                    //if user has no scheduled hrs for selected day generate schedule
                                    if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != ""
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                    {
                                        Schedule schedule = new Schedule();
                                        schedule.Day = currentDate.ToString();
                                        schedule.EmployeeID = emp.EmployeeId;
                                        //Aquire weather data for users city for currentdate
                                        var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                emp.CityID, currentDate);
                                        //determine schedule
                                        schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);
                                        _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                    }
                                    //Checks if email was already sent
                                    var emailSent = _userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                    if (!emailSent)
                                    {
                                        //send email
                                    }
                                    //Increment for loop
                                    i = i + 1;
                                    //move on to the next day
                                    currentDate = currentDate.AddDays(1);
                                }
                            }

                            break;
                        case "Saturday":
                            //Initialize counter
                            numOfDsays = 1;
                            //loop through each employees
                            foreach (var emp in employees)
                            {
                                //start schedule check loop
                                for (int i = 1; i <= numOfDsays;)
                                {
                                    //check if employees hrs were already scheduled for this day
                                    var hasSchedule = _userRepositoriesInterface.
                                       GetEmpScheduleByID(emp.EmployeeId, currentDate);
                                    //if user has no scheduled hrs for selected day generate schedule
                                    if (hasSchedule.EmployeeID != null && hasSchedule.EmployeeID != ""
                                                && dayOfWeek != "Sunday" && dayOfWeek != "Saturday")
                                    {
                                        Schedule schedule = new Schedule();
                                        schedule.Day = currentDate.ToString();
                                        schedule.EmployeeID = emp.EmployeeId;
                                        //Aquire weather data for users city for currentdate
                                        var empWeather = _weatherRepositoryInterface.GetWeatherDataByCityIDAndDate(
                                                emp.CityID, currentDate);
                                        //determine schedule
                                        schedule.Day = determineSchedule(empWeather.WeatherDesc, emp.Position.PositionName, emp.FullName);
                                        _userRepositoriesInterface.CreateEmployeeSchedule(schedule);
                                    }
                                    //Checks if email was already sent
                                    var emailSent = _userRepositoriesInterface.checkEmailSent(hasSchedule.ID);
                                    if (!emailSent)
                                    {
                                        //send email
                                    }
                                    //Increment for loop
                                    i = i + 1;
                                    //move on to the next day
                                    currentDate = currentDate.AddDays(1);
                                }
                            }

                            break;
                        default:
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



            return new string[] { "value1", "value2" };
        }

        private string determineSchedule(string weatherDesc, string positionName, string FullName)
        {
            if (weatherDesc == "")
            {
                return "to be decided";
            }
            else if (weatherDesc.ToLower().Contains("rain") && positionName.Contains("IT"))
            {
                return "Good day "
                    + FullName
                    + ". You are working remotely today.";
            }
            else if (weatherDesc.ToLower().Contains("rain") && !positionName.Contains("IT"))
            {
                return "Good day "
                    + FullName
                    + ". You are scheduled to only work for 4 hours today.";
            }
            else if (weatherDesc.ToLower().Contains("sun"))
            {
                return "Good day "
                    + FullName
                    + ". You are scheduled to work for 8 hours today.";
            }

            return "to be decided";

        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
