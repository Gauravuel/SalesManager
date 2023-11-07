using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Inventory
{
    public interface IPhoneCaseInventory
    {
        Task<PhoneCaseResponse> addPhoneCase(PhoneCaseView phoneCase);
        Task<SmartPhoneResponse> deletePhoneCase(string id);
        Task<GetPhoneCase> getPhoneCase();
        Task<GetSmartphones> getPhoneCaseById(PhoneCaseId phoneCaseId);
        Task<SmartPhoneResponse> updatePhoneCase(PhoneCaseView phoneCaseView);
    }
}