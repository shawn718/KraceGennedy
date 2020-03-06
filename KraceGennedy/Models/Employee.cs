
using Microsoft.AspNetCore.Identity;
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
    public class Employee
    {
        [Key, ForeignKey("ApplicationUser")]
        [Column(TypeName = "nvarchar(450)")]
        [Required(ErrorMessage = "This field is required.")]
        public string EmployeeId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("CityID")]
        public EmployeeCity City { get; set; }
        [DisplayName("City")]
        public int CityID { get; set; } 
        
        [ForeignKey("PositionID")]
        public Position Position { get; set; }
        [DisplayName("Position")]
        public int PositionID { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Telephone { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(35)")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "varchar(15)")]
        public char Gender { get; set; }
        
        

        [Column(TypeName = "varchar(30)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Branch Location")]
        public string Branch { get; set; }

    }

    public class ApplicationUser : IdentityUser
    {
    }
}
