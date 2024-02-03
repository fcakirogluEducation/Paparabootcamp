using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TokenAuth.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("all products");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Save()
        {
            return Ok("save product");
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        public IActionResult Update()
        {
            return Ok("update product");
        }


        [Authorize(Policy = "BirthDateCheckOver18")]
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("update product");
        }

        //[Authorize(Policy = "BirthDateCheck")]
        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    return Ok("update product");
        //}
    }
}