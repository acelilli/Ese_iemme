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


        //se c'è un errore nella insert potrebbe essere qui
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
    }
}
