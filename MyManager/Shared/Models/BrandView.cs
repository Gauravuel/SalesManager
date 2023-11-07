using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
  public class BrandView
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Brand name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public string Cat_id { get; set; }
        public string Category_Name { get; set; }
    }
}
