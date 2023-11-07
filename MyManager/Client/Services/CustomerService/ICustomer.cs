using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.CustomerService
{
    public interface ICustomer
    {
        Task<HttpResponseMessage> AddCustomer(CustomerView customer);
        Task<HttpResponseMessage> deleteCustomer(CustomerId customerId);
        Task<HttpResponseMessage> GetCustomer();
        Task<HttpResponseMessage> getCustomerById(CustomerId customerId);
        Task<HttpResponseMessage> updateCustomer(CustomerView customerView);
    }
}