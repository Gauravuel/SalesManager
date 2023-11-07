using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetTopPurchase
    {
        public bool Status { get; set; }
        public List<TopPurchaseModel> Purchases { get; set; } = new();
        public List<string> Cust_Name { get; set; } = new();
        public List<int> Amount { get; set; } = new();
        public List<string> Message { get; set; } = new();
    }
}
