using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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


            UtenteDTO? mioUtente = _service.CercaPerMailPassword(utDTO.Mail, utDTO.Pass);

            if (_service.VerificaEmailPassword(mioUtente))
            {
                
                //HttpContext.Session.SetString("userLogged", utDTO.Mail);
                //HttpContext.Session.SetString("userRole", utDTO.TipoUt);

                // Invece di fare così uso i CLAIMS

                //Creazione dei claims (verifica dell'utente autenticato)
                List<Claim> claimList = new List<Claim>()
                {
                    new Claim(JwtRegisteredClaimNames.Sub, mioUtente.Mail ),
                    new Claim("userType", mioUtente.TipoUt ),
                    //JTI crea un identifier univoco
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                //Chiave segreta per la firma del token:
                //nel program c'è la creazione dei parametri qui avviene, di fatto, l'emissione del token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key_super_segretissima_con_tantissimissimi_caratteri"));
                // dichiarazione l'argoritmo di cifratura
                var credz = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // creazione del token:
                var token = new JwtSecurityToken(
                    issuer: "Popolo",
                    audience: "Popolo",
                    claims: claimList,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credz
                );

                //Ritorno risposta ok in cui trasformiamo il Token in una stringa JWT (codificato)
                // ?
                string tkn = new JwtSecurityTokenHandler().WriteToken(token);
                //return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                return Redirect("/Home/Index");
            }

            // TO DO: Creazione cartella dei filtri con la classe apposita

            return Redirect("/Auth/Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Auth/Login");

        }
    }
}
