using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyManager.Client.Services.PurchaseService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.CustomerCart
{
    public class CustomerReceiptBase: ComponentBase
    {
       
        public GetPurchase getPurchase { get; set; } = new();
        [Inject]
        public IPurchase purchase { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        public PurchaseId purchaseId { get; set; } = new();
        [Parameter]
        public string purchaseid { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
       
        public IJSObjectReference ijsObjectReference;

        public async Task getPurchaseProduct()
        {
            purchaseId.Id = purchaseid;
            var result = await purchase.GetPurchaseProduct(purchaseId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getPurchase = await result.Content.ReadFromJsonAsync<GetPurchase>();

            }
            else
            {
                getPurchase = await result.Content.ReadFromJsonAsync<GetPurchase>();
                toastService.ShowWarning(getPurchase.Message.FirstOrDefault());
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await getPurchaseProduct();
        }
        public async Task PrintBill()
        {
            ijsObjectReference = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/Receipt.js");
            await ijsObjectReference.InvokeVoidAsync("printBill");
        }
    }
}
