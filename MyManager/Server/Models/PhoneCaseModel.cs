using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class PhoneCaseModel
    {
        public string Id { get; set; }
        public string Brand_Id { get; set; }
        public string Bill_Id { get; set; }
        public string Name { get; set; }
        public string Compatibility { get; set; }
        public string CaseMaterial { get; set; }
        public string Type { get; set; }
        public string Transparent { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        [ForeignKey("Brand_Id")]
        public BrandModel Brand { get; set; }
    }
}
