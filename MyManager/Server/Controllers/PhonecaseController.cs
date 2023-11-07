using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Inventory;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class PhonecaseController : Controller
    {
        private readonly IPhoneCaseInventory phoneCaseInventory;

        public PhonecaseController(IPhoneCaseInventory phoneCaseInventory)
        {
            this.phoneCaseInventory = phoneCaseInventory;
        }
        [Route("inventory/addphonecase")]
        [HttpPost]
        public async Task<IActionResult> addPhone(PhoneCaseView phoneCase)
        {
            var result = await phoneCaseInventory.addPhoneCase(phoneCase);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("inventory/getphonecase")]
        [HttpGet]
        public async Task<IActionResult> getPhone()
        {
            var result = await phoneCaseInventory.getPhoneCase();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/getphonecaseById")]
        [HttpPost]
        public async Task<IActionResult> getPhoneCaseById(PhoneCaseId phoneCaseId)
        {
            var result = await phoneCaseInventory.getPhoneCaseById(phoneCaseId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/updatephonecase")]
        [HttpPut]
        public async Task<IActionResult> updatePhoneCase(PhoneCaseView phoneCaseView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await phoneCaseInventory.updatePhoneCase(phoneCaseView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("inventory/deletephonecase/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deletePhoneCase(String Id)

        {

            var result = await phoneCaseInventory.deletePhoneCase(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
