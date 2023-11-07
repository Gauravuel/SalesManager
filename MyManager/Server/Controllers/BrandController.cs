using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Brand;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IProductBrand productBrand;

        public BrandController(IProductBrand productBrand)
        {
            this.productBrand = productBrand;
        }


        [Route("brand/addbrand")]
        [HttpPost]
        public async Task<IActionResult> addBrand(BrandView brand)
        {
            var result = await productBrand.addBrand(brand);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("brand/getbrand")]
        [HttpGet]
        public async Task<IActionResult> getBrand()
        {
            var result = await productBrand.getBrand();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("brand/getbrandById")]
        [HttpPost]
        public async Task<IActionResult> getBrand(BrandId brandId)
        {
            var result = await productBrand.getBrandById(brandId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("brand/updatebrand")]
        [HttpPut]
        public async Task<IActionResult> updateBrand(BrandView brandView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await productBrand.updateBrand(brandView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("brand/deletebrand/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteBrand(String Id)

        {

            var result = await productBrand.deleteBrand(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
