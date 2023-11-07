using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
   public class PurchaseView
    {
        public string Id { get; set; }    
        public string Customer_Id { get; set; }
        public int Discount { get; set; }
        public int Sum_Total { get; set; }
        [Required(ErrorMessage ="Amount cant be empty")]
        public int Paid_Amount { get; set; }
        public string Purchase_Date { get; set; }
        public string Purchase_Id { get; set; }
        public string Product_Id { get; set; }
        public string Product_name { get; set; }
        public int Quantity { get; set; } = 1;
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public List<PurchaseView> purchaseproduct { get; set; } = new();

    }
}
