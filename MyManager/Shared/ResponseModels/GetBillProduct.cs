using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetBillProduct
    {
        public bool Status { get; set; }
        public List<SmartphoneView> Smartphones { get; set; } = new();
        public List<HeadphoneView> Headphones { get; set; } = new();
        public List<ChargerView> Chargers { get; set; } = new();
        public List<PhoneCaseView> PhoneCases { get; set; } = new();     
        public List<string> Message { get; set; } = new();
       
    }
}
