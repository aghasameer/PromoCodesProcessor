using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodesProcessor.Models;
using PromoCodesProcessor.Services;

namespace PromoCodesProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UsersService _usersService;
        public UsersController(UsersService users)
        {
            _usersService = users;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var result = new Response();
            result = _usersService.GetUsers();
            return StatusCode(Convert.ToInt16(result.statuscode), result);
        }
    }
}
