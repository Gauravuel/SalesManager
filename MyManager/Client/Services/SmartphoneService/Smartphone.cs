using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.SmartphoneService
{
    public class Smartphone : ISmartphone
    {
        private readonly HttpClient httpClient;

        public Smartphone(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddSmartphone(SmartphoneView smartphoneView)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/addsmartphone", smartphoneView);
            return response;
        }

        public async Task<HttpResponseMessage> GetSmartphone()
        {
            var response = await httpClient.GetAsync("inventory/getsmartphone");
            return response;
        }

        public async Task<HttpResponseMessage> getSmartphoneById(SmartphoneId smartphoneId)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/getsmartphoneById", smartphoneId);
            return response;
        }

        public async Task<HttpResponseMessage> updateSmartphone(SmartphoneView smartphoneView)
        {

            var response = await httpClient.PutAsJsonAsync("inventory/updatesmartphone", smartphoneView);
            return response;
        }

        public async Task<HttpResponseMessage> deleteSmartphone(SmartphoneId smartphoneId)
        {
            var response = await httpClient.DeleteAsync($"inventory/deletesmartphone/{smartphoneId.Id}");
            return response;
        }
    }
}
