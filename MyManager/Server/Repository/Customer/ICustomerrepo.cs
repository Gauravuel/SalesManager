using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Customer
{
    public interface ICustomerrepo
    {
        Task<CustomerResponse> addCustomer(CustomerView customerView);
        Task<CustomerResponse> deleteCustomer(string id);
        Task<GetCustomer> getCustomer();
        Task<GetCustomer> getCustomerById(CustomerId customerId);
        Task<CustomerResponse> updateCustomer(CustomerView customerView);
    }
}