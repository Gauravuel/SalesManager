using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.CustomerService;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Customer
{
    public class ManageCustomerBase: ComponentBase
    {
        public GetCustomer getCustomer { get; set; } = new();
        [Inject]
        public ICustomer customer { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        CustomerResponse customerResponse = new();


        public string customerid { get; set; }

        public void setCustomerId(string id)
        {
            customerid = id;
        }

        public async Task getCustomers()
        {
            var result = await customer.GetCustomer();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getCustomer = await result.Content.ReadFromJsonAsync<GetCustomer>();

            }
            else
            {
                getCustomer = await result.Content.ReadFromJsonAsync<GetCustomer>();
                toastService.ShowWarning(getCustomer.Message.FirstOrDefault());
            }
        }
        public async Task customerDeleted(CustomerResponse view)
        {

            customerResponse = view;

            if (view.Status == true)
            {
                await getCustomers();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getCustomers();
        }
        public void successNotification()
        {
            foreach (var msg in customerResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }
         
        public void warningNotification()
        {
            foreach (var msg in customerResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
