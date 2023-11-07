using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Inventory
{
    public interface IChargerInventory
    {
        Task<ChargerResponse> addCharger(ChargerView chargerview);
        Task<ChargerResponse> deleteCharger(string id);
        Task<GetCharger> getCharger();
        Task<GetCharger> getChargerById(ChargerId chargerId);
        Task<ChargerResponse> updateCharger(ChargerView chargerView);
    }
}