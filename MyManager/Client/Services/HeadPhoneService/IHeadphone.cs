using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.HeadPhoneService
{
    public interface IHeadphone
    {
        Task<HttpResponseMessage> AddHeadphone(HeadphoneView headphoneView);
        Task<HttpResponseMessage> deleteHeadphone(HeadphoneId headphoneId);
        Task<HttpResponseMessage> GetHeadphone();
        Task<HttpResponseMessage> getHeadphoneById(HeadphoneId headphoneId);
        Task<HttpResponseMessage> updateHeadphone(HeadphoneView headphoneView);
    }
}