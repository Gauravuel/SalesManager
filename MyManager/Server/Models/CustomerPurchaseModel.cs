using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class CustomerPurchaseModel
    {
        public string Id { get; set; }
        public string Customer_Id { get; set; }
        public string Purchase_Id { get; set; }
        public string Purchase_Date { get; set; }
        public int Sum_Total { get; set; }
        public int PaidAmount { get; set; }
    }
}
