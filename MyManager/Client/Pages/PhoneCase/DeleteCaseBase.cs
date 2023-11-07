using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.PhoneCaseService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.PhoneCase
{
    public class DeleteCaseBase: ComponentBase
    {
        public PhoneCaseResponse phoneCaseResponse { get; set; } = new();

        [Inject]
        public IPhoneCase phoneCase { get; set; }

        [Parameter]
        public string phonecaseid { get; set; }
        public PhoneCaseId phoneCaseId { get; set; } = new();

        [Parameter]
        public EventCallback<PhoneCaseResponse> onDelete { get; set; }

        public async Task deleteCase()
        {
            phoneCaseId.Id = phonecaseid;
            var result = await phoneCase.deleteCase(phoneCaseId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                phoneCaseResponse = await result.Content.ReadFromJsonAsync<PhoneCaseResponse>();
                await onDelete.InvokeAsync(phoneCaseResponse);

            }
            else
            {
                phoneCaseResponse = await result.Content.ReadFromJsonAsync<PhoneCaseResponse>();
                await onDelete.InvokeAsync(phoneCaseResponse);
            }
        }
    }
}
