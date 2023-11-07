using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.ChargerService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Charger
{
    public class DeleteChargerBase:ComponentBase
    {
        public ChargerResponse chargerResponse { get; set; } = new();

        [Inject]
        public ICharger charger { get; set; }

        [Parameter]
        public string chargerid { get; set; }
        public ChargerId chargerId { get; set; } = new();

        [Parameter]
        public EventCallback<ChargerResponse> onDelete { get; set; }

        public async Task deleteCharger()
        {
            chargerId.Id = chargerid;
            var result = await charger.deleteCharger(chargerId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                chargerResponse = await result.Content.ReadFromJsonAsync<ChargerResponse>();
                await onDelete.InvokeAsync(chargerResponse);

            }
            else
            {
                chargerResponse = await result.Content.ReadFromJsonAsync<ChargerResponse>();
                await onDelete.InvokeAsync(chargerResponse);
            }
        }
    }
}
