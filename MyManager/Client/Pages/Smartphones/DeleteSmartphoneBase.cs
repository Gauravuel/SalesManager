using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.SmartphoneService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Smartphones
{
    public class DeleteSmartphoneBase: ComponentBase
    {
        public SmartPhoneResponse smartPhoneResponse { get; set; } = new();

        [Inject]
        public ISmartphone smartphone { get; set; }

        [Parameter]
        public string smartphoneid { get; set; }
        public SmartphoneId smartphoneId { get; set; } = new();

        [Parameter]
        public EventCallback<SmartPhoneResponse> onDelete { get; set; }

        public async Task deleteSmartphone()
        {
            smartphoneId.Id = smartphoneid;
            var result = await smartphone.deleteSmartphone(smartphoneId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                smartPhoneResponse = await result.Content.ReadFromJsonAsync<SmartPhoneResponse>();
                await onDelete.InvokeAsync(smartPhoneResponse);

            }
            else
            {
                smartPhoneResponse = await result.Content.ReadFromJsonAsync<SmartPhoneResponse>();
                await onDelete.InvokeAsync(smartPhoneResponse);
            }
        }
    }
}
