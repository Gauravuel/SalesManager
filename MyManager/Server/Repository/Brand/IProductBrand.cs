using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Brand
{
    public interface IProductBrand
    {
        Task<BrandResponse> addBrand(BrandView brand);
        Task<BrandResponse> deleteBrand(string id);
        Task<GetBrand> getBrand();
        Task<GetBrand> getBrandById(BrandId brandId);
        Task<BrandResponse> updateBrand(BrandView brandView);
    }
}