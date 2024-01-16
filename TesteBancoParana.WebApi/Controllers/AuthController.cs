using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Services;

namespace TesteBancoParana.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string userName, string password)
        {
            if (userName == "henriqueEizu" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Cliente());
                return Ok(token);
            }
            return BadRequest("Nome do usuário ou senha incorretos");
        }
    }
}
