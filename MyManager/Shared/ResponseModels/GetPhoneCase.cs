using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.ResponseModels
{
    public class GetPhoneCase
    {
        public bool Status { get; set; }
        public List<PhoneCaseView> PhoneCases { get; set; } = new();
        public List<string> Message { get; set; } = new();
        public PhoneCaseView SingleCase { get; set; }
    }
}
