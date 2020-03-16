using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Models
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage = "Your email address is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your first name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public char Gender { get; set; }

        [Display(Name = "Telephone Number")]
        public string TelephoneNum { get; set; }

        public int PositionId { get; set; }
        public List<Position> position { get; set; }

        public string RoleId { get; set; }
        public List<Role> Role { get; set; }

        public string Branch { get; set; }

        public int CityID { get; set; }
        public List<EmployeeCity> city { get; set; }

        public string Country { get; set; }

        [Required (ErrorMessage = "Your password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display (Name = "Confirm Password")]
        [Required (ErrorMessage = "Your confrmation of password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword {get; set;}
    }
}
