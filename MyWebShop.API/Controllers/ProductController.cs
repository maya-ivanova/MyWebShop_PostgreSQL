using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebShop.Library.Contracts;
using MyWebShop.Library.Models;
using System.Runtime.CompilerServices;
using Google.Protobuf.Collections;

namespace MyWebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;   
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode= StatusCodes.Status200OK, Type= typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll());
        }
    }
}
