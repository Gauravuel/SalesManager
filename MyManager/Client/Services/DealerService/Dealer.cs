using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.DealerService
{
    public class Dealer : IDealer
    {
        private readonly HttpClient httpClient;

        public Dealer(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddDealer(DealerView dealer)
        {
            var response = await httpClient.PostAsJsonAsync("dealer/adddealer", dealer);
            return response;
        }

        public async Task<HttpResponseMessage> GetDealer()
        {
            var response = await httpClient.GetAsync("dealer/getdealer");
            return response;
        }

        public async Task<HttpResponseMessage> getDealerById(DealerId dealerId)
        {
            var response = await httpClient.PostAsJsonAsync("dealer/getdealerById", dealerId);
            return response;
        }

        public async Task<HttpResponseMessage> updateDealer(DealerView dealerView)
        {
            //var json = JsonConverter.SerializeObject(categoryView);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PutAsJsonAsync("dealer/updatedealer", dealerView);
            return response;
        }

        public async Task<HttpResponseMessage> deleteDealer(DealerId dealerId)
        {
            var response = await httpClient.DeleteAsync($"dealer/deletedealer/{dealerId.Id}");
            return response;
        }
    }
}
