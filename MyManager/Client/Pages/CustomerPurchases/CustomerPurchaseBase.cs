using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.PurchaseService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.CustomerPurchases
{
    public class CustomerPurchaseBase: ComponentBase
    {
        public GetPurchase getPurchase { get; set; } = new();
        [Inject]
        public IPurchase purchase { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        public CustomerId customerId { get; set; } = new();
        [Parameter]
        public string  custid { get; set; }

        public async Task getPurchases()
        {
            customerId.Id = custid;
            var result = await purchase.GetPurchaseById(customerId);
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
            await getPurchases();
        }
    }
}
