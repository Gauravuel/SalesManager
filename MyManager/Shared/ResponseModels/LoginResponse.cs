using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
    }
}
