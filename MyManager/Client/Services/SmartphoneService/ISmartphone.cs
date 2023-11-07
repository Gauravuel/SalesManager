using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.SmartphoneService
{
    public interface ISmartphone
    {
        Task<HttpResponseMessage> AddSmartphone(SmartphoneView smartphoneView);
        Task<HttpResponseMessage> deleteSmartphone(SmartphoneId smartphoneId);
        Task<HttpResponseMessage> GetSmartphone();
        Task<HttpResponseMessage> getSmartphoneById(SmartphoneId smartphoneId);
        Task<HttpResponseMessage> updateSmartphone(SmartphoneView smartphoneView);
    }
}