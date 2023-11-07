using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.CustomerService
{
    public class Customer : ICustomer
    {
        private readonly HttpClient httpClient;

        public Customer(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddCustomer(CustomerView customer)
        {
            var response = await httpClient.PostAsJsonAsync("customer/addcustomer", customer);
            return response;
        }

        public async Task<HttpResponseMessage> GetCustomer()
        {
            var response = await httpClient.GetAsync("customer/getcustomer");
            return response;
        }

        public async Task<HttpResponseMessage> getCustomerById(CustomerId customerId)
        {
            var response = await httpClient.PostAsJsonAsync("customer/getCustomerById", customerId);
            return response;
        }

        public async Task<HttpResponseMessage> updateCustomer(CustomerView customerView)
        {
            //var json = JsonConverter.SerializeObject(categoryView);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PutAsJsonAsync("customer/updatecustomer", customerView);
            return response;
        }

        public async Task<HttpResponseMessage> deleteCustomer(CustomerId customerId)
        {
            var response = await httpClient.DeleteAsync($"customer/deletecustomer/{customerId.Id}");
            return response;
        }
    }
}
