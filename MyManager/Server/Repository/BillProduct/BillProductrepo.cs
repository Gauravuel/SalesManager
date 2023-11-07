using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyManager.Server.Data;
using MyManager.Server.Models;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.BillProduct
{
    public class BillProductrepo : IBillProductrepo
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public BillProductrepo(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<GetBillProduct> GetProducts(BillId billId)
        {
            GetBillProduct billProduct = new();
            try
            {


                var billids = await context.BillProducts.Where(d => d.Billid == billId.Id).ToListAsync();
                if (billids?.Any() == true)
                {
                    foreach (var billproduct in billids)
                    {
                        var smartphone = await context.Smartphones.FindAsync(billproduct.Productid);
                        var headphone = await context.Headphone.FindAsync(billproduct.Productid);
                        var phonecase = await context.PhoneCase.FindAsync(billproduct.Productid);
                        var charger = await context.Charger.FindAsync(billproduct.Productid);
                        if (smartphone != null)
                        {
                            var smartphonemap = mapper.Map<SmartphoneView>(smartphone);
                            smartphonemap.Quantity = billproduct.Quantity;
                            billProduct.Smartphones .Add(smartphonemap);
                        }

                        if (charger != null)
                        {
                            var chargermap = mapper.Map<ChargerView>(charger);
                            chargermap.Quantity = billproduct.Quantity;
                            billProduct.Chargers.Add(chargermap);
                        }
                        if (headphone != null)
                        {
                            var headphonemap = mapper.Map<HeadphoneView>(headphone);
                            headphonemap.Quantity = billproduct.Quantity;
                            billProduct.Headphones.Add(headphonemap);
                        }
                        if (phonecase != null)
                        {
                            var phonecasemap = mapper.Map<PhoneCaseView>(phonecase);
                            phonecasemap.Quantity = billproduct.Quantity;
                            billProduct.PhoneCases.Add(phonecasemap);
                        }

                    
                    }
                    billProduct.Status = true;
                    return billProduct;
                }
                billProduct.Status = true;
                billProduct.Message.Add("No any products registered");
                return billProduct;
          
            }
            catch (Exception e)
            {
                billProduct.Status = true;
                billProduct.Message.Add(e.Message);
                return billProduct;
            }
        }
    }
}
