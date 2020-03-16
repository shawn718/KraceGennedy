using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KraceGennedy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KraceGennedy.Data
{
    public class KraceGennedyContext : IdentityDbContext
    {
        public KraceGennedyContext (DbContextOptions<KraceGennedyContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeCity> Cities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<WeatherInfo> WeatherInfos { get; set; }
        public DbSet<EmailTracker> EmailTrackers { get; set; }

        //seed table with data
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<EmployeeCity>().HasData(
                    new EmployeeCity { ID = 1, CityName = "Parish of Saint Andrew" },
                    new EmployeeCity { ID = 2, CityName = "Kingston" },
                    new EmployeeCity { ID = 3, CityName = "Parish of Saint James" },
                    new EmployeeCity { ID = 4, CityName = "Montego Bay" },
                    new EmployeeCity { ID = 5, CityName = "Parish of Westmoreland" },
                    new EmployeeCity { ID = 6, CityName = "Whitehall" },
                    new EmployeeCity { ID = 7, CityName = "Parish of Saint Catherine" },
                    new EmployeeCity { ID = 8, CityName = "Rest Pen" },
                    new EmployeeCity { ID = 9, CityName = "Portmore" },
                    new EmployeeCity { ID = 10, CityName = "Beacon Hill" },
                    new EmployeeCity { ID = 11, CityName = "Parish of Trelawny" },
                    new EmployeeCity { ID = 12, CityName = "Albert Town" },
                    new EmployeeCity { ID = 13, CityName = "Parish of Saint Ann" },
                    new EmployeeCity { ID = 14, CityName = "Bamboo" },
                    new EmployeeCity { ID = 15, CityName = "Parish of Clarendon" },
                    new EmployeeCity { ID = 16, CityName = "Bryans Pen" },
                    new EmployeeCity { ID = 17, CityName = "Parish of Hanover" },
                    new EmployeeCity { ID = 18, CityName = "Lucea" },
                    new EmployeeCity { ID = 19, CityName = "Phoenix Park" },
                    new EmployeeCity { ID = 20, CityName = "Parish of Portland" },
                    new EmployeeCity { ID = 21, CityName = "Port Antonio" },
                    new EmployeeCity { ID = 22, CityName = "Parish of Saint Mary" },
                    new EmployeeCity { ID = 23, CityName = "Mannings Town" },
                    new EmployeeCity { ID = 24, CityName = "Bull Bay" },
                    new EmployeeCity { ID = 25, CityName = "Sandy Bay" },
                    new EmployeeCity { ID = 26, CityName = "August Town" },
                    new EmployeeCity { ID = 27, CityName = "Gregory Park" },
                    new EmployeeCity { ID = 28, CityName = "Parish of Saint Elizabeth" },
                    new EmployeeCity { ID = 29, CityName = "Hopewell" },
                    new EmployeeCity { ID = 30, CityName = "Bethlehem" },
                    new EmployeeCity { ID = 31, CityName = "Little London" },
                    new EmployeeCity { ID = 32, CityName = "Albert Arms" },
                    new EmployeeCity { ID = 33, CityName = "Lionel Town" },
                    new EmployeeCity { ID = 34, CityName = "Harbour View" },
                    new EmployeeCity { ID = 35, CityName = "Clarks Town" }, 
                    new EmployeeCity { ID = 36, CityName = "Bog Walk" },
                    new EmployeeCity { ID = 37, CityName = "Passage Fort" },
                    new EmployeeCity { ID = 38, CityName = "Minho" },
                    new EmployeeCity { ID = 39, CityName = "Plum Corner" },
                    new EmployeeCity { ID = 40, CityName = "Liberty Valley" },
                    new EmployeeCity { ID = 41, CityName = "Stony Hill" },
                    new EmployeeCity { ID = 42, CityName = "Up Park Camp" },
                    new EmployeeCity { ID = 43, CityName = "Santa Maria" },
                    new EmployeeCity { ID = 44, CityName = "Parish of Saint Thomas" },
                    new EmployeeCity { ID = 45, CityName = "Old Lee Gate" },
                    new EmployeeCity { ID = 46, CityName = "Mount Nebo" },
                    new EmployeeCity { ID = 47, CityName = "Central Village" },
                    new EmployeeCity { ID = 48, CityName = "Clarendon Park" },
                    new EmployeeCity { ID = 49, CityName = "Matildas Corner" },
                    new EmployeeCity { ID = 50, CityName = "Liguanea" },
                    new EmployeeCity { ID = 51, CityName = "Papine" },
                    new EmployeeCity { ID = 52, CityName = "Mona Heights" },
                    new EmployeeCity { ID = 53, CityName = "Glengoffe" },
                    new EmployeeCity { ID = 54, CityName = "Dumblane" },
                    new EmployeeCity { ID = 55, CityName = "Comfort Village" },
                    new EmployeeCity { ID = 56, CityName = "Rectory" },
                    new EmployeeCity { ID = 57, CityName = "Thatch Pen" }
                );

            builder.Entity<Position>().HasData(
                    new Position { ID = 1, PositionName = "ITManager"},
                    new Position { ID = 2, PositionName = "HRManager"},
                    new Position { ID = 3, PositionName = "SecurityManager"},
                    new Position { ID = 4, PositionName = "GeneralManager"},
                    new Position { ID = 5, PositionName = "ITSoftwareDeveloper"},
                    new Position { ID = 6, PositionName = "HREmployee"},
                    new Position { ID = 7, PositionName = "CheifFinancialOfficer"},
                    new Position { ID = 8, PositionName = "CheifExecutiveOfficer"},
                    new Position { ID = 9, PositionName = "CheifOpperationsOfficer"},
                    new Position { ID = 10, PositionName = "RegularEmployee"},
                    new Position { ID = 11, PositionName = "ITSystemAdministrator"}
                );
           
        }
    }

    internal class Branch
    {
    }
}
