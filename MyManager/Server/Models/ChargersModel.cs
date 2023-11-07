using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class ChargersModel
    {
        public string Id { get; set; }
        public string Brand_Id { get; set; }
        public string Bill_Id { get; set; }     
        public string Chargername { get; set; }
        public int Watt { get; set; }
        public int Port { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Fast_Charging { get; set; }
        [ForeignKey("Brand_Id")]
        public BrandModel Brand { get; set; }

    }
}
