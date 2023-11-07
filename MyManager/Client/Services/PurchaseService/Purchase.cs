using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.PurchaseService
{
    public class Purchase : IPurchase
    {
        private readonly HttpClient httpClient;

        public Purchase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddPurchase(PurchaseView purchaseView)
        {
            var response = await httpClient.PostAsJsonAsync("purchase/addpurchase", purchaseView);
            return response;
        }
        public async Task<HttpResponseMessage> GetPurchaseById(CustomerId customerId)
        {
            var response = await httpClient.PostAsJsonAsync("purchase/getpurchaseById", customerId);
            return response;
        }
        public async Task<HttpResponseMessage> GetPurchaseProduct(PurchaseId purchaseId)
        {
            var response = await httpClient.PostAsJsonAsync("purchase/getpurchaseproduct", purchaseId);
            return response;
        }
        public async Task<HttpResponseMessage> GetCustomerCredit()
        {
            var response = await httpClient.GetAsync("purchase/getcustomercredit");
            return response;
        }
        public async Task<HttpResponseMessage> DeleteCredit(CreditId creditId)
        {
            var response = await httpClient.DeleteAsync($"purchase/deletecredit/{creditId.Id}");
            return response;
        }
        public async Task<HttpResponseMessage> GetGroupedPurchase()
        {
            var response = await httpClient.GetAsync("purchase/getgroupedpurchase");
            return response;
        }
        public async Task<HttpResponseMessage> GetTopPurchase()
        {
            var response = await httpClient.GetAsync("purchase/gettoppurchase");
            return response;
        }
    }
}
