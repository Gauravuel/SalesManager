using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.CustomerService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Customer
{
    public class AddCustomerBase: ComponentBase
    {
        public CustomerView customerView { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public CustomerResponse customerResponse { get; set; } = new();

        public CustomerId customerId { get; set; } = new();
        public GetCustomer getCustomer { get; set; } = new();
        [Inject]
        public ICustomer customer { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        [Parameter]
        public string Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task handleSubmit()
        {
            if (string.IsNullOrEmpty(Id))
            {
                await addCustomer();
            }
            else
            {
                await updateCustomer();
            }
        }

        public async Task addCustomer()
        {
            var result = await customer.AddCustomer(customerView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customerResponse = await result.Content.ReadFromJsonAsync<CustomerResponse>();
                //dealerView.Name = "";
                //dealerView.Adress = "";
                //dealerView.Phone = "";
                successNotification();
            }
            else
            {
                customerResponse = await result.Content.ReadFromJsonAsync<CustomerResponse>();
                warningNotification();
            }
        }
        public async Task updateCustomer()
        {
            customerView.Id = Id;
            var result = await customer.updateCustomer(customerView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo("/managecustomer");
            }
            else
            {
                customerResponse = await result.Content.ReadFromJsonAsync<CustomerResponse>();
                warningNotification();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                customerId.Id = Id;
                var result = await customer.getCustomerById(customerId);
                getCustomer = await result.Content.ReadFromJsonAsync<GetCustomer>();
                customerView = getCustomer.Singlecustomer;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
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
