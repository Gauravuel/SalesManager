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
    public class DeleteCustomerBase: ComponentBase
    {
        public CustomerResponse customerResponse { get; set; } = new CustomerResponse();

        [Inject]
        public ICustomer customer { get; set; }

        [Parameter]
        public string customerid { get; set; }
        public CustomerId customerId { get; set; } = new();

        [Parameter]
        public EventCallback<CustomerResponse> onDelete { get; set; }

        public async Task deleteCredit()
        {
            customerId.Id = customerid;
            var result = await customer.deleteCustomer(customerId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customerResponse = await result.Content.ReadFromJsonAsync<CustomerResponse>();
                await onDelete.InvokeAsync(customerResponse);

            }
            else
            {
                customerResponse = await result.Content.ReadFromJsonAsync<CustomerResponse>();
                await onDelete.InvokeAsync(customerResponse);
            }
        }
    }
}
