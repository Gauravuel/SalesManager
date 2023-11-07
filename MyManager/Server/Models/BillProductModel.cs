using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Models
{
    public class BillProductModel
    {
        public string Id { get; set; }

        public string Productid { get; set; }
        public string  Billid { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Billid")]
        public BillModel billModel { get; set; }
        //[ForeignKey("Productid")]
        //public SmartPhonesModel smartPhonesModel { get; set; }
        //[ForeignKey("Productid")]
        //public ChargersModel chargersModel { get; set; }
        //[ForeignKey("Productid")]
        //public HeadphoneModel headphoneModel { get; set; }
        //[ForeignKey("Productid")]
        //public PhoneCaseModel phoneCaseModel { get; set; }
    }
}
