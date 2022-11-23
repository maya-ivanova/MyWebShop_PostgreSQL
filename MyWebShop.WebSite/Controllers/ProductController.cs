using Microsoft.AspNetCore.Mvc;
using MyWebShop.Library.Contracts;

namespace MyWebShop.WebSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAll();
            return View(products);
        }
    }
}
