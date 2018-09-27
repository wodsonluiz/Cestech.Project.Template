using Cestech.Api.ProviderJWT;
using Cestech.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cestech.Api.Controllers
{
    public class TokenController : Controller
    {
        private readonly IApplicationServiceUsuario _service;
        public TokenController(IApplicationServiceUsuario service)
        {
            _service = service;
        }

        [Route("api/CreateToken")]
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateToken([FromBody] string NomeUsuario, string Senha)
        {
            if (string.IsNullOrEmpty(NomeUsuario) || string.IsNullOrEmpty(Senha))
                return Unauthorized();


                        
            var token = new TokenJWTBuilder()
                .AddSecurityKey(ProviderJWT.JWTSecurityKey.Create("Secret_Key-Cestech"))
                .AddSubject(NomeUsuario)
                .AddIssuer("Securiry.Bearer")
                .AddAudience("Securiry.Bearer")
                .AddClaim("UsuarioAPI", "1")
                .AddExpiry(5)
                .Builder();

            return Ok(token.value);

        }
    }
}