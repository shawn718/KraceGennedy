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
    public class Schedule
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
        [DisplayName("Employee")]
        [Column(TypeName = "nvarchar(450)")]
        public string EmployeeID { get; set; }

        public string Day { get; set; }
        public string Hours { get; set; }
    }
}
