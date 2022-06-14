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
    public class ParticipantesController : ControllerBase
    {
        private readonly IParticipanteService _participanteService;

        public ParticipantesController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        [HttpGet]
        [Route("obterIdosos")]
        public ActionResult<IEnumerable<Participante>> GetIdosos()
        {
            return Ok(_participanteService.ObterIdososVálidos());
        }

        [HttpGet]
        [Route("obterDeficientesFisico")]
        public ActionResult<IEnumerable<Participante>> GetDeficienteFisicos()
        {
            return Ok(_participanteService.ObterDeficienteFisicosValidos());
        }

        [HttpGet]
        [Route("obterGerais")]
        public ActionResult<IEnumerable<Participante>> GetGerais()
        {
            return Ok(_participanteService.ObterGeraisValidos());
        }

        [HttpGet]
        [Route("realizarSorteio")]
        public ActionResult<IEnumerable<Participante>> RealizaSorteio()
        {
            return Ok(_participanteService.RealizarSorteio());
        }
    }
}
