using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.ChargerService
{
    public class Charger : ICharger
    {
        private readonly HttpClient httpClient;

        public Charger(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddCharger(ChargerView chargerView)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/addcharger", chargerView);
            return response;
        }

        public async Task<HttpResponseMessage> GetCharger()
        {
            var response = await httpClient.GetAsync("inventory/getcharger");
            return response;
        }

        public async Task<HttpResponseMessage> getChargerById(ChargerId chargerId)
        {
            var response = await httpClient.PostAsJsonAsync("inventory/getChargerById", chargerId);
            return response;
        }

        public async Task<HttpResponseMessage> updateCharger(ChargerView chargerView)
        {

            var response = await httpClient.PutAsJsonAsync("inventoryupdatecharger", chargerView);
            return response;
        }

        public async Task<HttpResponseMessage> deleteCharger(ChargerId chargerId)
        {
            var response = await httpClient.DeleteAsync($"inventory/deletecharger/{chargerId.Id}");
            return response;
        }
    }
}
