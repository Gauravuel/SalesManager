using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Purchase;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaserepo purchaserepo;

        public PurchaseController(IPurchaserepo purchaserepo)
        {
            this.purchaserepo = purchaserepo;
        }

        [Route("purchase/addpurchase")]
        [HttpPost]
        public async Task<IActionResult> addPurchase(PurchaseView purchase)
        {
            var result = await purchaserepo.addPurchase(purchase);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("purchase/getpurchase")]
        [HttpPost]
        public async Task<IActionResult> getPurchase()
        {
            var result = await purchaserepo.getPurchase();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("purchase/getpurchaseById")]
        [HttpPost]
        public async Task<IActionResult> getPurchase(CustomerId customerId)
        {
            var result = await purchaserepo.getPurchaseById(customerId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [Route("purchase/getpurchaseproduct")]
        [HttpPost]
        public async Task<IActionResult> getPurchaseProduct(PurchaseId purchaseId)
        {
            var result = await purchaserepo.getPurchaseProduct(purchaseId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [Route("purchase/getcustomercredit")]
        [HttpGet]
        public async Task<IActionResult> getCustomerCredit()
        {
            var result = await purchaserepo.getCustomerCredit();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [Route("purchase/deletecredit/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deletecredit(string id)
        {
            var result = await purchaserepo.removecredit(id);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("purchase/getgroupedpurchase")]
        [HttpGet]
        public async Task<IActionResult> getGroupedPurchase()
        {
            var result = await purchaserepo.getGroupByPurchase();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [Route("purchase/gettoppurchase")]
        [HttpGet]
        public async Task<IActionResult> getTopPurchase()
        {
            var result = await purchaserepo.getTopPurchase();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        //[Route("purchase/updatepurchase")]
        //[HttpPatch]
        //public async Task<IActionResult> updatePurchase(PurchaseView purchase)
        //{
        //    //var serialized = JsonConvert.SerializeObject(services);
        //    //var deserialized = JsonConvert.DeserializeObject(serialized);
        //    //var map = mapper.Map<ServicesModel>(deserialized);
        //    var result = await purchaserepo.updatePurchase(purchase);
        //    if (result.Status == true)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound(result);


        //}

        //[Route("purchase/deletepurchase/{Id}")]
        //[HttpDelete]
        //public async Task<IActionResult> deletePurchase(String Id)

        //{

        //    var result = await purchaserepo.deletePurchase(Id);
        //    if (result.Status == true)
        //    {
        //        return Ok(result);
        //    }

        //    return NotFound(result);
        //}

    }
}
