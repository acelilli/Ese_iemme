using API_VacanGio.Services;
using API_VacanGio.Controllers;
using Microsoft.AspNetCore.Mvc;
using API_VacanGio.Models;

namespace API_VacanGio.Controllers
{
    [ApiController]
    [Route("api/destinazioni")]
    public class DestinazioneController : Controller
    {
        private readonly DestinazioneServices _service;

        public DestinazioneController(DestinazioneServices serv)
        {
            _service = serv;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DestinazioneDTO>> ListaDestinazioni()
        {
            return Ok(_service.CercaTutti());
        }

        [HttpGet("{varCodice}")]
        public ActionResult<DestinazioneDTO?> DettaglioDestinazione(string varCodice)
        {
            if (string.IsNullOrWhiteSpace(varCodice))
                return BadRequest();

            DestinazioneDTO? risultato = _service.CercaPerCodice(varCodice);
            if (risultato is not null)
                return Ok(risultato);

            return NotFound();
        }

        [HttpPost]
        [Route("inserisci")]
        public IActionResult Inserisci(DestinazioneDTO destDTO)
        {
            if (string.IsNullOrWhiteSpace(destDTO.Nom) || string.IsNullOrWhiteSpace(destDTO.Pae))
                return BadRequest();
            if (_service.Inserisci(destDTO))
                return Ok();
            return BadRequest(destDTO);
        }


        [HttpPut("{varCodice}")]
        public IActionResult ModificaDestinazione(string varCodice, DestinazioneDTO destDTO)
        {
            if (string.IsNullOrWhiteSpace(varCodice) ||
                 string.IsNullOrWhiteSpace(destDTO.Nom) ||
                 string.IsNullOrWhiteSpace(destDTO.Pae)||
                 string.IsNullOrWhiteSpace(destDTO.ImU))
                return BadRequest();

            destDTO.CodDes = varCodice;

            if (_service.Aggiorna(destDTO))
                return Ok();

            return BadRequest();
        }
     }
}
