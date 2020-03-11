using KraceGennedy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Interfaces
{
    public interface IUserRepositoriesInterface
    {
        public List<EmployeeCity> GetCities();
        public List<Position> GetPositions();
        public void CreateEmployee(Employee emp);
        public Employee GetEmployeeByEmail(string email);
        public List<Employee> GetEmployees();
        public Schedule GetEmpScheduleByID(string empId, DateTime period);
        public void CreateEmployeeSchedule(Schedule schedule);
        public bool checkEmailSent(int scheduleId);
    }
}
