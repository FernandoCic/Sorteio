using Microsoft.AspNetCore.Mvc;
using Sorteio.API.Services.Interface;
using Sorteio.Data.Repository.Interface;
using Sorteio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorteio.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteService _participanteService;

        public ParticipanteController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participante>> GetIdosos()
        {
            return Ok(_participanteService.ObterIdososVálidos());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participante>> GetDeficienteFisicos()
        {
            return Ok(_participanteService.ObterDeficienteFisicosValidos());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participante>> GetGerais()
        {
            return Ok(_participanteService.ObterGeraisValidos());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Participante>> RealizaSorteio()
        {
            return Ok(_participanteService.RealizarSorteio());
        }
    }
}
