using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.HeadPhoneService
{
    public class Headphone : IHeadphone
    {
        private readonly HttpClient httpClient;

        public Headphone(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> AddHeadphone(HeadphoneView headphoneView)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/addheadphone", headphoneView);
            return response;
        }

        public async Task<HttpResponseMessage> GetHeadphone()
        {
            var response = await httpClient.GetAsync("inventory/getheadphone");
            return response;
        }

        public async Task<HttpResponseMessage> getHeadphoneById(HeadphoneId headphoneId)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/getheadphoneById", headphoneId);
            return response;
        }

        public async Task<HttpResponseMessage> updateHeadphone(HeadphoneView headphoneView)
        {

            var response = await httpClient.PutAsJsonAsync("inventory/updateheadphone", headphoneView);
            return response;
        }

        public async Task<HttpResponseMessage> deleteHeadphone(HeadphoneId headphoneId)
        {
            var response = await httpClient.DeleteAsync($"inventory/deleteheadphone/{headphoneId.Id}");
            return response;
        }

    }
}
