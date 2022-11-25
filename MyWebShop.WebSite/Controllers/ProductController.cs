using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyWebShop.Library.Contracts;
using MyWebShop.Library.Models;

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
        public IActionResult Add()
        {
            var model = new ProductDto();
            ViewData["Title"] = "Add new product";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductDto model)
        {
            ViewData["Title"] = "Add new product";
            if(!ModelState.IsValid) return View(model);
            await productService.Add(model);
            return RedirectToAction(nameof(Index));

        }
    }
}
