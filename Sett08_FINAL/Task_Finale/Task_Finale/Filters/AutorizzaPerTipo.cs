using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Task_Finale.Filters
{
    public class AutorizzaPerTipo : Attribute, IAuthorizationFilter
    {
        private readonly string _tipoUtente;
        public AutorizzaPerTipo(string tipoUtente) 
        { 
            _tipoUtente = tipoUtente;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claims = context.HttpContext.User.Claims;
            var userType = claims.FirstOrDefault(c => c.Type == "userType")?.Value;

            if (userType is null || userType != _tipoUtente) 
            { 
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
