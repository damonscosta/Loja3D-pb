using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Loja3D.Controllers {
    // Esta linha define que o endereço será "/Auth"
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        // Esta rota cria o endereço "/Auth/login"
        [HttpGet("login")]
        public IActionResult Login() {
            // Manda o usuário para o Google e pede pra voltar para a Home ("/")
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, GoogleDefaults.AuthenticationScheme);
        }

        // Esta rota cria o endereço "/Auth/logout"
        [HttpGet("logout")]
        public async Task<IActionResult> Logout() {
            // Apaga o cookie de login
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}