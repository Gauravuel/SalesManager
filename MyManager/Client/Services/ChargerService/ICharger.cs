using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.ChargerService
{
    public interface ICharger
    {
        Task<HttpResponseMessage> AddCharger(ChargerView chargerView);
        Task<HttpResponseMessage> deleteCharger(ChargerId chargerId);
        Task<HttpResponseMessage> GetCharger();
        Task<HttpResponseMessage> getChargerById(ChargerId chargerId);
        Task<HttpResponseMessage> updateCharger(ChargerView chargerView);
    }
}