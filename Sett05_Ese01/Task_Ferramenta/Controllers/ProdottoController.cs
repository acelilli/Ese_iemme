using Microsoft.AspNetCore.Mvc;
using Task_Ferramenta.Models;
using Task_Ferramenta.Services;

namespace Task_Ferramenta.Controllers
{
    [ApiController]
    [Route("api/prodotto")]
    public class ProdottoController : Controller
    {
        private readonly ProdottoServices _service;
        public ProdottoController(ProdottoServices service)
        {
            _service = service;
        }
        [HttpGet("{varCod}")]
        public ActionResult<ProdottoDTO?> CercaPerCodice(string varCod)
        {
            if (string.IsNullOrWhiteSpace(varCod))
                return BadRequest();

            ProdottoDTO? risultato = _service.Cerca(varCod);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }
    }
}
