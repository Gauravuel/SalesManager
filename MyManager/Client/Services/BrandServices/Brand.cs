using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.BrandServices
{
    public class Brand : IBrand
    {
        private readonly HttpClient httpClient;

        public Brand(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddBrand(BrandView brand)
        {
            var response = await httpClient.PostAsJsonAsync("brand/addbrand", brand);
            return response;
        }

        public async Task<HttpResponseMessage> GetBrand()
        {
            var response = await httpClient.GetAsync("brand/getbrand");
            return response;
        }


        public async Task<HttpResponseMessage> getBrandById(BrandId brandId)
        {
            var response = await httpClient.PostAsJsonAsync("brand/getbrandById", brandId);
            return response;


        }
        public async Task<HttpResponseMessage> deleteBrand(BrandId brandId)
        {
            var response = await httpClient.DeleteAsync($"brand/deletebrand/{brandId.Id}");
            return response;

        }
        public async Task<HttpResponseMessage> updateBrand(BrandView brandView)
        {
            //var json = JsonConverter.SerializeObject(categoryView);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PutAsJsonAsync("brand/updatebrand", brandView);
            return response;
        }
    }
}
