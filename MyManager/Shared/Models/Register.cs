
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{

    //This model is UserData while registering the user
    public class Register
    {
    
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
       
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Compare("Password", ErrorMessage = "Password doesnot match.")]
        public string ConfirmPassword { get; set; }

        //public string token { get; set; }
    }
}
