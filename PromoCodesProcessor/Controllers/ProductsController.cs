using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromoCodesProcessor.Models;
using PromoCodesProcessor.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromoCodesProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductsService _productsService;
        public ProductsController(ProductsService products)
        {
            _productsService = products;
        }

        [HttpGet]
        [Route("/api/Products")]
        public IActionResult Products()
        {
            var result = new Response();
            result = _productsService.GetProducts();

            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }


        [HttpGet]
        [Route("/api/Categories")]
        public IActionResult Categories()
        {
            var result = new Response();
            result = _productsService.GetCategories();

            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

    }
}
