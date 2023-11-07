using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
    public class ChargerView
    {

        public string Id { get; set; }
        [Required]
        public string Brand_Id { get; set; }
        [Required]
        public string Bill_Id { get; set; }
        [Required]
        public string Chargername { get; set; }
        [Required]
        public int Watt { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Fast_Charging { get; set; }
    }
}
