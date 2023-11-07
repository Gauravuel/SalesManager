using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Data;
using MyManager.Server.Repository.Inventory;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class SmartphoneController : Controller
    {
        private readonly ISmartphonesinventory smartphonesinventory;

        public SmartphoneController(ISmartphonesinventory smartphonesinventory)
        {
            this.smartphonesinventory = smartphonesinventory;
        }

        [Route("inventory/addsmartphone")]
        [HttpPost]
        public async Task<IActionResult> addPhone(SmartphoneView product)
        {
            var result = await smartphonesinventory.addPhone(product);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("inventory/getsmartphone")]
        [HttpGet]
        public async Task<IActionResult> getPhone()
        {
            var result = await smartphonesinventory.getPhone();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/getsmartphoneById")]
        [HttpPost]
        public async Task<IActionResult> getPhoneById(SmartphoneId productId)
        {
            var result = await smartphonesinventory.getPhoneById(productId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/updatesmartphone")]
        [HttpPut]
        public async Task<IActionResult> updatePhone(SmartphoneView productView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await smartphonesinventory.updatePhone(productView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("inventory/deletesmartphone/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deletePhone(String Id)

        {

            var result = await smartphonesinventory.deletePhone(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
