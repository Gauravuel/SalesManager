using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetHeadphone
    {
        public bool Status { get; set; }
        public List<HeadphoneView> Headphones { get; set; } = new();
        public List<string> Message { get; set; } = new();
        public HeadphoneView SingleHeadphone { get; set; }
    }
}
