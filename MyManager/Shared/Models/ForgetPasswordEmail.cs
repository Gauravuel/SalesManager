using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
    public class ForgetPasswordEmail
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        public string Email { get; set; }
    }
}
