using Microsoft.AspNetCore.Mvc;
using Task_Finale.Models;
using Task_Finale.Services;

namespace Task_Finale.Controllers
{
    public class AuthController : Controller
    {
        #region Service Injection

        private readonly UtenteServices _service;

        public AuthController(UtenteServices service)
        {
            _service = service;
        }

        #endregion
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verifica(UtenteDTO utDTO)
        {

            if (string.IsNullOrWhiteSpace(utDTO.Mail) || string.IsNullOrWhiteSpace(utDTO.Pass))
                return Redirect("/Auth/Login");

            if (_service.VerificaEmailPassword(utDTO))
            {
                HttpContext.Session.SetString("userLogged", utDTO.TipoUt);
                return Redirect("/Home");
            }

            return Redirect("/Auth/Login");
        }
    }
}
