using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class BrandModel
    {
        public string Id { get; set; }
       
        public string Cat_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Cat_id")]
        public CategoryModel Category { get; set; }
    }
}
