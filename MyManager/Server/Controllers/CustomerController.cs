using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Customer;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerrepo customerrepo;

        public CustomerController(ICustomerrepo customerrepo)
        {
            this.customerrepo = customerrepo;
        }


        [Route("customer/addcustomer")]
        [HttpPost]
        public async Task<IActionResult> addCustomer(CustomerView customer)
        {
            var result = await customerrepo.addCustomer(customer);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("customer/getcustomer")]
        [HttpGet]
        public async Task<IActionResult> getCustomer()
        {
            var result = await customerrepo.getCustomer();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("customer/getCustomerById")]
        [HttpPost]
        public async Task<IActionResult> getCustomer(CustomerId customerId)
        {
            var result = await customerrepo.getCustomerById(customerId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("customer/updatecustomer")]
        [HttpPut]
        public async Task<IActionResult> updateCustomer(CustomerView customerView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await customerrepo.updateCustomer(customerView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("customer/deletecustomer/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> dfeleteCustomer(String Id)

        {

            var result = await customerrepo.deleteCustomer(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
