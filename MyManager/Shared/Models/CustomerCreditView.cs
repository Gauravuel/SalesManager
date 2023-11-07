using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
    public class CustomerCreditView
    {
        public string Id { get; set; }
        public string Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        //public int Discount { get; set; }
        public int Sum_Total { get; set; }
        public int Paid_Amount { get; set; }
        public string Purchase_Date { get; set; }
        public string Purchase_Id { get; set; }
        public int Credited_amount { get; set; }
    }
}
