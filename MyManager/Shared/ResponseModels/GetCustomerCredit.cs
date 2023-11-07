using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetCustomerCredit
    {
        public bool Status { get; set; }
        public List<CustomerCreditView> CustomerCredit { get; set; } = new();
        public List<string> Message { get; set; } = new();
        public CustomerCreditView singleCustomerCredit { get; set; }
    }
}
