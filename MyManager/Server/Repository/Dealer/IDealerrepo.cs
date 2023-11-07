using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Dealer
{
    public interface IDealerrepo
    {
        Task<DealerResponse> addDealer(DealerView dealer);
        Task<DealerResponse> deleteDealer(string id);
        Task<GetDealer> getDealer();
        Task<GetDealer> getDealerById(DealerId dealerId);
        Task<DealerResponse> updateDealer(DealerView dealerView);
    }
}