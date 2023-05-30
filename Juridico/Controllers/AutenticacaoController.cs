using Juridico.Application.Seguranca.Interfaces;
using Juridico.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Juridico.UI.Web.Controllers
{
    public class AutenticacaoController : BaseController
    {
        private readonly ILoginApp _loginApp;

        public AutenticacaoController(ILoginApp loginApp, INotificador notificador) : base(notificador)
        {
            _loginApp = loginApp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string cpf, string senha)
        {
            bool flPossuiLogin = await _loginApp.PossuiLogin(cpf, senha);

            if (!flPossuiLogin)
            {
                NotificarErro("CPF e/ou Senha Inválidos");
                return CustomResponse();
            }

            var claims = new List<Claim>
            {
                new Claim("CPF", cpf)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                IssuedUtc = DateTime.Now,
                ExpiresUtc = DateTime.Now.AddMinutes(60),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

            return CustomResponse(cpf);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            //HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
