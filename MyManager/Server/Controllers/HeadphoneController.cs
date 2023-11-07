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
    public class HeadphoneController : Controller
    {
        private readonly IHeadphoneInventory headphoneInventory;

        public HeadphoneController(IHeadphoneInventory headphoneInventory)
        {
            this.headphoneInventory = headphoneInventory;
        }

        [Route("inventory/addheadphone")]
        [HttpPost]
        public async Task<IActionResult> addHeapPhone(HeadphoneView headphone)
        {
            var result = await headphoneInventory.addHeadphone(headphone);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("inventory/getheadphone")]
        [HttpGet]
        public async Task<IActionResult> getHeadphone()
        {
            var result = await headphoneInventory.getHeadphone();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/getheadphoneById")]
        [HttpPost]
        public async Task<IActionResult> getHeadphoneById(HeadphoneId headphoneId)
        {
            var result = await headphoneInventory.getHeadphoneById(headphoneId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/updateheadphone")]
        [HttpPut]
        public async Task<IActionResult> updateHeadphone(HeadphoneView headphoneView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await headphoneInventory.updateHeadphone(headphoneView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("inventory/deleteheadphone/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteHeadphone(String Id)

        {

            var result = await headphoneInventory.deleteHeadphone(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
