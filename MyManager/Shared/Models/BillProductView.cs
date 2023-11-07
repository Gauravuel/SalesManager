using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
    public class BillProductView
    {
        public string Id { get; set; }

        public string Productid { get; set; }
        public string Billid { get; set; }
        public int Quantity { get; set; }
    }
}
