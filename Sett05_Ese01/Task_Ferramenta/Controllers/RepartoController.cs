using Microsoft.AspNetCore.Mvc;
using Task_Ferramenta.Models;
using Task_Ferramenta.Services;

namespace Task_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/reparto")]
    public class RepartoController : Controller
    {
        private readonly RepartoServices _service;
        public RepartoController(RepartoServices service) {
            _service = service;
        }
        [HttpGet("{varCod}")]
        public ActionResult<RepartoDTO?> CercaPerCodice(string varCod)
        {
            if (string.IsNullOrWhiteSpace(varCod))
                return BadRequest();

            RepartoDTO? risultato = _service.Cerca(varCod);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpGet("tutti")]
        public ActionResult<List<RepartoDTO>> ElencoReparti()
        {
            var reparti = _service.Lista();

            if (reparti is not null)
                return Ok(reparti);

            return NotFound();
        }
    }
}
