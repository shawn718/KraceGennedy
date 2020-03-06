using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Your email address is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
