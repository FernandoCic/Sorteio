using Sorteio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorteio.API.Services.Interface
{
    public interface IParticipanteService
    {
        IEnumerable<Participante> ObterIdososVálidos();
        IEnumerable<Participante> ObterDeficienteFisicosValidos();
        IEnumerable<Participante> ObterGeraisValidos();
        IEnumerable<Participante> RealizarSorteio();
    }
}
