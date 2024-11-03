using Microsoft.AspNetCore.Mvc;
using Task_Finale.Services;

namespace Task_Finale.Controllers
{
    public class UtenteController : Controller
    {
        #region Service Injection

        private readonly UtenteServices _service;

        public UtenteController(UtenteServices service)
        {
            _service = service;
        }

        #endregion

        public IActionResult Lista() 
        {
            string? utenteLoggato = HttpContext.Session.GetString("userLogged");

            if (utenteLoggato is not null && utenteLoggato == "Admin")
            {
                ViewBag.userSelected = "Admin";
                //To do: Popolamento della lista
                return View();
            }

            return Redirect("/Auth/Login");
        } 
    }
}
