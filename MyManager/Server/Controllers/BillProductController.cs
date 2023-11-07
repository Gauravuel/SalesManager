using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.BillProduct;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class BillProductController : Controller
    {
        private readonly IBillProductrepo billProductrepo;
  
        public BillProductController(IBillProductrepo billProductrepo)
        {
            this.billProductrepo = billProductrepo;
        }
        [Route("bill/billproduct")]
        [HttpPost]
        public async Task<IActionResult> getBill(BillId billId)
        {
            var result = await billProductrepo.GetProducts(billId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
