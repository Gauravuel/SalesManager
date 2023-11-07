using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
   public class GetPurchase
    {
        public bool Status { get; set; }
        public List<PurchaseView> Purchases { get; set; } = new();
        public List<string> Message { get; set; } = new();
        public PurchaseView PurchaseProduct { get; set; } = new();
    }
}
