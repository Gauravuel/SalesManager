using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetCategory
    {
        public bool Status { get; set; }
        public List<CategoryView> Categories { get; set; } = new();
        public List<String> Message { get; set; } = new();
        public CategoryView Singlecategory { get; set; }
    }
}
