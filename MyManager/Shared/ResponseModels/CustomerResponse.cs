using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class CustomerResponse
    {
        public bool Status { get; set; }
        public List<string> Message { get; set; } = new();
        public string Type { get; set; }
    }
}
