using KraceGennedy.Interfaces;
using KraceGennedy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Data
{
    public class UserRepository : IUserRepositoriesInterface
    {
        private readonly KraceGennedyContext _context;

        public UserRepository(KraceGennedyContext context)
        {
            _context = context;
        }

        public List<EmployeeCity> GetCities()
        {
            var result = _context.Cities.OrderBy(x => x.CityName).ToList();

            return result;
        }

        public List<Position> GetPositions()
        {
            var result = _context.Positions.ToList();

            return result;
        }

        public void CreateEmployee(Employee emp)
        {
            _context.Employee.Add(emp);
            _context.SaveChanges();
        }

        public Employee GetEmployeeByEmail(string email)
        {
            var res = _context.Employee
                .Where(x => x.Email == email)
                .FirstOrDefault();

            return res;
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }

        public Schedule GetEmpScheduleByID(string empId, DateTime period)
        {
            //fetch schedule
            var res = _context.Schedules.Where(x => x.EmployeeID == empId).FirstOrDefault();
            Schedule schedule = new Schedule();
            //checked if null
            if (res != null)
            {
                schedule = res;
            }

            return schedule;
        }

        public void CreateEmployeeSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public bool CheckEmailSent(int scheduleId)
        {
            var res = _context.EmailTrackers
                .Where(x => x.ScheduleId == scheduleId)
                .FirstOrDefault();

            if(res.Schedule.Hours != null && res.Schedule.Hours != "")
            {
                return true;
            }

            return false;
        }
    }
}
