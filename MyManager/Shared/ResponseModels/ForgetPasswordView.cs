using System;
using System.Collections.Generic;
using System.Text;

namespace MyManager.Shared.ResponseModels
{
    public class ForgetPasswordView
    {
        public string Type { get; set; }
        public bool Status { get; set; }

        public string Message { get; set; }
    }
}
