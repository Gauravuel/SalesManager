using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Bill;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillrepo billrepo;

        public BillController(IBillrepo billrepo)
        {
            this.billrepo = billrepo;
        }


        [Route("bill/addbill")]
        [HttpPost]
        public async Task<IActionResult> addBill(BillView bill)
        {
            var result = await billrepo.addBill(bill);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("bill/getbill")]
        [HttpGet]
        public async Task<IActionResult> getBill()
        {
            var result = await billrepo.getBill();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("bill/getbillById")]
        [HttpPost]
        public async Task<IActionResult> getBill(BillId billId)
        {
            var result = await billrepo.getBillById(billId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("bill/updatebill")]
        [HttpPut]
        public async Task<IActionResult> updateBill(BillView billView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await billrepo.updateBill(billView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("bill/deletebill/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteBill(String Id)

        {

            var result = await billrepo.deleteBill(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
