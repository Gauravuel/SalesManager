using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class BillModel
    {
        public string Id { get; set; }
        public string Dealer_Id { get; set; }
        public DateTime Checkout_Date { get; set; }
        //public int Total { get; set; }       
        public int BillNo { get; set; }

    }
}
