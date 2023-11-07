using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.BillService
{
    public class Bill : IBill
    {
        private readonly HttpClient httpClient;

        public Bill(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddBill(BillView bill)
        {
            var response = await httpClient.PostAsJsonAsync("bill/addbill", bill);
            return response;
        }

        public async Task<HttpResponseMessage> GetBill()
        {
            var response = await httpClient.GetAsync("bill/getbill");
            return response;
        }


        public async Task<HttpResponseMessage> getBillById(BillId billId)
        {
            var response = await httpClient.PostAsJsonAsync("bill/getbillById", billId);
            return response;
        }

        public async Task<HttpResponseMessage> deleteBill(BillId billId)
        {
            var response = await httpClient.DeleteAsync($"bill/deletebill/{billId.Id}");
            return response;
        }

        public async Task<HttpResponseMessage> updateBill(BillView billView)
        {
            var response = await httpClient.PutAsJsonAsync("bill/updatebill", billView);
            return response;
        }
    }
}
