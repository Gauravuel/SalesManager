using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BillProductService;
using MyManager.Client.Services.BillService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.BillProduct
{
    public class BillProductBase: ComponentBase
    {
        public GetBillProduct getBillProduct { get; set; } = new();
        [Inject]
        public IBillProduct billProduct { get; set; }
        public GetBill getBill { get; set; } = new();
        [Inject]
        public IBill bill { get; set; }
        public BillId billId { get; set; } = new();
        [Parameter]
        public string billid { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        public int Total { get; set; }=0;
        public async Task GetBillProduct()
        {
            billId.Id = billid;
            var result = await billProduct.GetBillProduct(billId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getBillProduct = await result.Content.ReadFromJsonAsync<GetBillProduct>();
                await calcualte();
            }
            else
            {
                getBillProduct = await result.Content.ReadFromJsonAsync<GetBillProduct>();
                toastService.ShowWarning(getBillProduct.Message.FirstOrDefault());
            }
        }
        public async Task getBillById() // to get bill and dealer information
        {
            if (!string.IsNullOrEmpty(billid))
            {
                billId.Id = billid;
                var result = await bill.getBillById(billId);
                getBill = await result.Content.ReadFromJsonAsync<GetBill>();            
               
            }
        }
        public async Task calcualte()
        {
            if (getBillProduct.Headphones.Any())
            {
                foreach(var headphone in getBillProduct.Headphones)
                {
                    Total += headphone.Quantity * headphone.Price;
                }
            }
            if (getBillProduct.Smartphones.Any())
            {
                foreach (var smartphone in getBillProduct.Smartphones)
                {
                    Total += smartphone.Quantity * smartphone.Price;
                }
            }
            if (getBillProduct.Chargers.Any())
            {
                foreach (var charger in getBillProduct.Chargers)
                {
                    Total += charger.Quantity * charger.Price;
                }
            }
            if (getBillProduct.PhoneCases.Any())
            {
                foreach (var phonecase in getBillProduct.PhoneCases)
                {
                    Total += phonecase.Quantity * phonecase.Price;
                }
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await getBillById();
            await GetBillProduct();
        }
    }
}
