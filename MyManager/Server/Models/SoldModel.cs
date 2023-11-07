using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class SoldModel
    {
        public string Id { get; set; }
        public string Customer_Id { get; set; }
        public string Product_Id { get; set; }
        public string Purchase_Id { get; set; }
        public string Product_name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
        public int  Discount { get; set; }
        public string Purchase_Date { get; set; }
    }
}
