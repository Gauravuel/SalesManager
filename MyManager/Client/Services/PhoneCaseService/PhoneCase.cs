using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.PhoneCaseService
{
    public class PhoneCase : IPhoneCase
    {
        private readonly HttpClient httpClient;

        public PhoneCase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddCase(PhoneCaseView phoneCase)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/addphonecase", phoneCase);
            return response;
        }

        public async Task<HttpResponseMessage> GetCase()
        {
            var response = await httpClient.GetAsync("inventory/getphonecase");
            return response;
        }

        public async Task<HttpResponseMessage> getCaseById(PhoneCaseId phoneCaseId)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/getphonecaseById", phoneCaseId);
            return response;
        }

        public async Task<HttpResponseMessage> updateCase(PhoneCaseView phoneCaseView)
        {
            //var json = JsonConverter.SerializeObject(categoryView);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PutAsJsonAsync("inventory/updatephonecase", phoneCaseView);
            return response;
        }

        public async Task<HttpResponseMessage> deleteCase(PhoneCaseId phoneCaseId)
        {
            var response = await httpClient.DeleteAsync($"inventory/deletephonecase/{phoneCaseId.Id}");
            return response;
        }
    }
}
