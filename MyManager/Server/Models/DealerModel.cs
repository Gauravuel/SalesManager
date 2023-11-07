using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class DealerModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Dealer name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Dealer address is required.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Dealer contact is required.")]
        public string Phone { get; set; }
    }
}
