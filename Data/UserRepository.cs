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

    }
}
