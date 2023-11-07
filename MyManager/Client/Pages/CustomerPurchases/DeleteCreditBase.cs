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
    public class DeleteCreditBase: ComponentBase
    {
        public CustomerCreditResponse customerCreditResponse { get; set; } = new CustomerCreditResponse();

        [Inject]
        public IPurchase purchase { get; set; }

        [Parameter]
        public string creditid { get; set; }
        //public creditId customerId { get; set; } = new();
        public CreditId creditId { get; set; } = new();
        [Parameter]
        public EventCallback<CustomerCreditResponse> onDelete { get; set; }

        public async Task deleteCredit()
        {
            creditId.Id = creditid;
            var result = await purchase.DeleteCredit(creditId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customerCreditResponse = await result.Content.ReadFromJsonAsync<CustomerCreditResponse>();
                await onDelete.InvokeAsync(customerCreditResponse);

            }
            else
            {
                customerCreditResponse = await result.Content.ReadFromJsonAsync<CustomerCreditResponse>();
                await onDelete.InvokeAsync(customerCreditResponse);
            }
        }
    }
}
