using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
   public class GetCustomer
    {
        public bool Status { get; set; }
        public List<CustomerView> Customers { get; set; } = new();
        public List<string> Message { get; set; } = new();
        public CustomerView Singlecustomer { get; set; }
    }
}
