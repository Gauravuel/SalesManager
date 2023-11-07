using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetSmartphones
    {
        public bool Status { get; set; }
        public List<SmartphoneView> Smartphones { get; set; } = new();
        public List<string> Message { get; set; } = new();
        public SmartphoneView Singleproduct { get; set; }
    }
}
