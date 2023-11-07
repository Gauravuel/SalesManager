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
    public class ChargerController : Controller
    {
        private readonly IChargerInventory chargerInventory;

        public ChargerController(IChargerInventory chargerInventory)
        {
            this.chargerInventory = chargerInventory;
        }

        [Route("inventory/addcharger")]
        [HttpPost]
        public async Task<IActionResult> addCharger(ChargerView chargerView)
        {
            var result = await chargerInventory.addCharger(chargerView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("inventory/getcharger")]
        [HttpGet]
        public async Task<IActionResult> getCharger()
        {
            var result = await chargerInventory.getCharger();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventory/getChargerById")]
        [HttpPost]
        public async Task<IActionResult> getChargerById(ChargerId chargerId)
        {
            var result = await chargerInventory.getChargerById(chargerId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("inventoryupdatecharger")]
        [HttpPut]
        public async Task<IActionResult> updatePhone(ChargerView chargerView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await chargerInventory.updateCharger(chargerView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("inventory/deletecharger/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteCharger(String Id)

        {

            var result = await chargerInventory.deleteCharger(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
