using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.DealerService;
using MyManager.Shared.ResponseModels;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Dealer
{
    public class ManageDealerBase: ComponentBase
    {
        public GetDealer getDealer { get; set; } = new();
        [Inject]
        public IDealer dealer { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        DealerResponse dealerResponse = new();


        public string dealerid { get; set; }

        public void setDealerId(string id)
        {
            dealerid = id;
        }

        public async Task getDealers()
        {
            var result = await dealer.GetDealer();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getDealer = await result.Content.ReadFromJsonAsync<GetDealer>();

            }
            else
            {
                getDealer = await result.Content.ReadFromJsonAsync<GetDealer>();
                toastService.ShowWarning(getDealer.Message.FirstOrDefault());
            }
        }
          public async Task dealerDeleted(DealerResponse view)
        {

            dealerResponse = view;

            if (view.Status == true)
            {
                await getDealers();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getDealers();
        }
        public void successNotification()
        {
            foreach (var msg in dealerResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in dealerResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }

}
