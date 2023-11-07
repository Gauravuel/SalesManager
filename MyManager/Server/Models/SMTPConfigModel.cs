using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class SMTPConfigModel
    {
        public string SenderAddress { get; set; }
        public string SenderName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnablesSSL { get; set; }
        public bool USerDefaultCredentials { get; set; }
        public bool IsBodyHTML { get; set; }
    }
}
