using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.PurchaseService;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.CustomerPurchases
{
    public class CustomerCreditBase: ComponentBase
    {
        public GetCustomerCredit getCustomerCredit { get; set; } = new();
        [Inject]
        public IPurchase purchase { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        public string credit_id { get; set; }
        public CustomerCreditResponse customerCreditResponse { get; set; } = new();
        public void setCreditId(string id)
        {
            credit_id = id;
        }
        public async Task getCustomerCredits()
        {
           
            var result = await purchase.GetCustomerCredit();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getCustomerCredit = await result.Content.ReadFromJsonAsync<GetCustomerCredit>();

            }
            else
            {
                getCustomerCredit = await result.Content.ReadFromJsonAsync<GetCustomerCredit>();
                toastService.ShowWarning(getCustomerCredit.Message.FirstOrDefault());
            }
        }
        public async Task creditCleared(CustomerCreditResponse response)
        {

            customerCreditResponse = response;

            if (response.Status == true)
            {
                await getCustomerCredits();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getCustomerCredits();
        }
        public void successNotification()
        {
            foreach (var msg in customerCreditResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in customerCreditResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
