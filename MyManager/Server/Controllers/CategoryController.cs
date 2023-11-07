using Microsoft.AspNetCore.Mvc;
using MyManager.Server.Repository.Category;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Controllers
{
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IProductCategory productCategory;

        public CategoryController(IProductCategory productCategory)
        {
            this.productCategory = productCategory;
        }

        [Route("category/addcategory")]
        [HttpPost]
        public async Task<IActionResult> addCategory(CategoryView category)
        {
            var result = await productCategory.addCategory(category);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [Route("category/getcategory")]
        [HttpGet]
        public async Task<IActionResult> getCategory()
        {
            var result = await productCategory.getCategory();
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("category/getcategoryById")]
        [HttpPost]
        public async Task<IActionResult> getCategory(CategoryId categoryId)
        {
            var result = await productCategory.getCategoryById(categoryId);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [Route("category/updatecategory")]
        [HttpPut]
        public async Task<IActionResult> updateCategory(CategoryView categoryView)
        {
            //var serialized = JsonConvert.SerializeObject(services);
            //var deserialized = JsonConvert.DeserializeObject(serialized);
            //var map = mapper.Map<ServicesModel>(deserialized);
            var result = await productCategory.updateCategory(categoryView);
            if (result.Status == true)
            {
                return Ok(result);
            }
            return NotFound(result);


        }

        [Route("category/deletecategory/{Id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteCategory(String Id)

        {

            var result = await productCategory.deleteCategory(Id);
            if (result.Status == true)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
