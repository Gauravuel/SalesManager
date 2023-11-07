using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class ChangePasswordView
    {
        public string Type { get; set; }
        public bool Status { get; set; }

        public List<string> Message { get; set; } = new();
    }
}
