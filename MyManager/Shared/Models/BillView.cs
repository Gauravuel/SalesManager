﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyManager.Shared.Models
{
  public class BillView
    {
        public string Id { get; set; }
        public DateTime Checkout_Date { get; set; }
        //public int Total { get; set; }
        public string Dealer_Id { get; set; }
        public DealerView dealerView { get; set; }
        public int BillNo { get; set; }
    }
}
