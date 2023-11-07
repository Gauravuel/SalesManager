using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
   public class ChangePasswordModel
    {
        public string userEmail { get; set; }
        [Required(ErrorMessage = "Previous Password is required")]
        public string PrevPassword { get; set; }
        [Required(ErrorMessage = "Current Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirmation Password is required")]
        [Compare("Password", ErrorMessage = "Password Doesnot match")]
        public string ConfirmPassword { get; set; }
    }
}
