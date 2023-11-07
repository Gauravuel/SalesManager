using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class SmartPhonesModel
    {
        public string Id { get; set; }
        public string Brand_Id { get; set; }
        public string Bill_Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Ram { get; set; }
        public int Storage { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Cpu { get; set; }
        public string Display { get; set; }
        [ForeignKey("Brand_Id")]
        public BrandModel Brand { get; set; }
    }
}
