using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
    public class ForgetPasswordCred
    {

        public string Id { get; set; }

        public string Token { get; set; }

        [Required(ErrorMessage = "Password in required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm-Password in required.")]
        [Compare("Password",ErrorMessage ="Password doesnot match")]
        public string ConfirmPassword { get; set; }
    }
}
