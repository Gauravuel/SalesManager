using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.HeadPhoneService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Headphone
{
    public class DeleteHeadphoneBase: ComponentBase
    {
        public HeadphoneResponse headphoneResponse { get; set; } = new();

        [Inject]
        public IHeadphone headphone { get; set; }

        [Parameter]
        public string headphoneid { get; set; }
        public HeadphoneId headphoneId { get; set; } = new();

        [Parameter]
        public EventCallback<HeadphoneResponse> onDelete { get; set; }

        public async Task deleteHeadphone()
        {
            headphoneId.Id = headphoneid;
            var result = await headphone.deleteHeadphone(headphoneId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                headphoneResponse = await result.Content.ReadFromJsonAsync<HeadphoneResponse>();
                await onDelete.InvokeAsync(headphoneResponse);

            }
            else
            {
                headphoneResponse = await result.Content.ReadFromJsonAsync<HeadphoneResponse>();
                await onDelete.InvokeAsync(headphoneResponse);
            }
        }
    }
}
