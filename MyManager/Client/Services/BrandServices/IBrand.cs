using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.BrandServices
{
    public interface IBrand
    {
        Task<HttpResponseMessage> AddBrand(BrandView brand);
        Task<HttpResponseMessage> GetBrand();
        Task<HttpResponseMessage> getBrandById(BrandId brandId);
        Task<HttpResponseMessage> deleteBrand(BrandId brandId);
        Task<HttpResponseMessage> updateBrand(BrandView brandView);
    }
}