using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.DealerService
{
    public interface IDealer
    {
        Task<HttpResponseMessage> AddDealer(DealerView dealer);
        Task<HttpResponseMessage> deleteDealer(DealerId dealerId);
        Task<HttpResponseMessage> GetDealer();
        Task<HttpResponseMessage> getDealerById(DealerId dealerId);
        Task<HttpResponseMessage> updateDealer(DealerView dealerView);
    }
}