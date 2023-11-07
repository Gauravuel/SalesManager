using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Dealer;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class DealerController : Controller
    {
        private readonly IDealerrepo dealerrepo;

        public DealerController(IDealerrepo dealerrepo)
        {
            this.dealerrepo = dealerrepo;
        }

        [Route("dealer/adddealer")]
        [HttpPost]
        public async Task<IActionResult> addDealer(DealerView dealer)
        {
            var result = await dealerrepo.addDealer(dealer);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("dealer/getdealer")]
        [HttpGet]
        public async Task<IActionResult> getDealer()
        {
            var result = await dealerrepo.getDealer();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("dealer/getdealerById")]
        [HttpPost]
        public async Task<IActionResult> getDealer(DealerId dealerId)
        {
            var result = await dealerrepo.getDealerById(dealerId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("dealer/updatedealer")]
        [HttpPut]
        public async Task<IActionResult> updateDealer(DealerView dealerView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await dealerrepo.updateDealer(dealerView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("dealer/deletedealer/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteDealer(String Id)

        {

            var result = await dealerrepo.deleteDealer(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
