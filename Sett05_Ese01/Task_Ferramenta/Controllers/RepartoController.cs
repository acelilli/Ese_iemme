using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost]
        public IActionResult InserisciReparto(RepartoDTO repDTO) 
        {
            if((repDTO.Nom.IsNullOrEmpty()) || (repDTO.Fil.IsNullOrEmpty()))
                return BadRequest();

            if (_service.InserisciReparto(repDTO))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{varCodice}")]
        public IActionResult EliminaReparto(string varCodice) 
        {
            if(string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            RepartoDTO? daCancellare = _service.Cerca(varCodice);

            if(daCancellare is not null)
                return Ok();

            return NotFound();
        }
    }
}
