using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.DealerService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Dealer
{
    public class DeleteDealerBase: ComponentBase
    {
        public DealerResponse dealerResponse { get; set; } = new DealerResponse();

        [Inject]
        public IDealer dealer { get; set; }

        [Parameter]
        public string dealerid { get; set; }
        public DealerId dealerId { get; set; } = new();

        [Parameter]
        public EventCallback<DealerResponse> onDelete { get; set; }

        public async Task deletedealer()
        {
            dealerId.Id = dealerid;
            var result = await dealer.deleteDealer(dealerId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                dealerResponse = await result.Content.ReadFromJsonAsync<DealerResponse>();
                await onDelete.InvokeAsync(dealerResponse);

            }
            else
            {
                dealerResponse = await result.Content.ReadFromJsonAsync<DealerResponse>();
                await onDelete.InvokeAsync(dealerResponse);
            }
        }
    }
}
