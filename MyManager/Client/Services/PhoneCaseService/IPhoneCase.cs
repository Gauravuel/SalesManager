using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.PhoneCaseService
{
    public interface IPhoneCase
    {
        Task<HttpResponseMessage> AddCase(PhoneCaseView phoneCase);
        Task<HttpResponseMessage> deleteCase(PhoneCaseId phoneCaseId);
        Task<HttpResponseMessage> GetCase();
        Task<HttpResponseMessage> getCaseById(PhoneCaseId phoneCaseId);
        Task<HttpResponseMessage> updateCase(PhoneCaseView phoneCaseView);
    }
}