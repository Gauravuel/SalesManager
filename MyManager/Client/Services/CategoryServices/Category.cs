using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyManager.Client.Services.CategoryServices
{
    public class Category : ICategory
    {
        private readonly HttpClient httpClient;

        public Category(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddCategory(CategoryView category)
        {
            var response = await httpClient.PostAsJsonAsync("category/addcategory", category);
            return response;
        }
    
        public async Task<HttpResponseMessage> GetCategory()
        {
            var response = await httpClient.GetAsync("category/getcategory");
            return response;
        }

        //public async Task<HttpResponseMessage> getLimitedServices(ServiceId id)
        //{
        //    var response = await httpClient.PostAsJsonAsync("services/getLimitedServices", id);
        //    return response;
        //}


        //public async Task<HttpResponseMessage> addService(ServiceView serviceModel)
        //{
        //    var response = await httpClient.PostAsJsonAsync("services/addServices", serviceModel);
        //    return response;
        //}


        public async Task<HttpResponseMessage> getCategoryById(CategoryId categoryId)
        {
            var response = await httpClient.PostAsJsonAsync("category/getcategoryById", categoryId);
            return response;


        }

        public async Task<HttpResponseMessage> updateCategory(CategoryView categoryView)
        {
            //var json = JsonConverter.SerializeObject(categoryView);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await httpClient.PutAsJsonAsync("category/updatecategory", categoryView);
            return response;


        }
        public async Task<HttpResponseMessage> deleteCategory(CategoryId categoryId)
        {
            var response = await httpClient.DeleteAsync($"category/deletecategory/{categoryId.Id}");
            return response;

        }


    }
}
