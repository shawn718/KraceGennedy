using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Models
{
    public class WeatherInfo
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("CityID")]
        public EmployeeCity City { get; set; }
        [DisplayName("City")]
        public int CityID { get; set; }

        public DateTime Day { get; set; }
        public string WeatherDesc { get; set; }
    }
}
