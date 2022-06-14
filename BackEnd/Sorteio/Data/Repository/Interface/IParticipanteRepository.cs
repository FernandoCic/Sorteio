using Sorteio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorteio.Data.Repository.Interface
{
    public interface IParticipanteRepository
    {
        IEnumerable<Participante> ObterTodosIdosos();

        IEnumerable<Participante> ObterTodosDeficienteFisicos();
        IEnumerable<Participante> ObterTodosGeral();
    }
}
