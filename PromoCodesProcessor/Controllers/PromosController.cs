using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromoCodesProcessor.Models;
using PromoCodesProcessor.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromoCodesProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromosController : ControllerBase
    {

        private readonly Promo_CodesService _promosService;
        public PromosController(Promo_CodesService promos)
        {
            _promosService = promos;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = new Response();
            result = _promosService.GetPromos();
            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

        [HttpGet("{id}")]
        public IActionResult Get_Id(int id)
        {
            var result = new Response();
            result = _promosService.GetPromo(id);
            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

        [HttpPost]
        public IActionResult Post(CreatePromo promo)
        {

            var result = new Response();
            result = _promosService.CreatePromo(promo);
            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

        [HttpPut]
        public IActionResult Put(UpdatePromo promo)
        {

            var result = new Response();
            result = _promosService.UpdatePromo(promo);
            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = new Response();
            result = _promosService.DeletePromo(id);
            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

        [HttpPost]
        [Route("Redeem")]
        public IActionResult Redeem(CheckRedeem redeem)
        {
            var result = new Response();
            result = _promosService.RedeemCode(redeem);

            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }

        [HttpPost]
        [Route("Purchase")]
        public IActionResult Purchase(PurchasePromo purchase)
        {
            var result = new Response();
            result = _promosService.PurchasePromo(purchase);

            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }
    }
}
