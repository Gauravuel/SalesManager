using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class RegisterViewModel
    {
        public bool status { get; set; }
        public List<string> Message { get; set; } = new List<string>();
        public string type { get; set; }
        public string id { get; set; }
    }
}
