using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.BillProductService
{
    public class BillProduct : IBillProduct
    {
        private readonly HttpClient httpClient;

        public BillProduct(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetBillProduct(BillId billId)
        {
            var response = await httpClient.PostAsJsonAsync("bill/billproduct", billId);
            return response;
        }
    }
}
