using CsvHelper;
using CsvHelper.Configuration;
using Sorteio.Data.Repository.Interface;
using Sorteio.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sorteio.Data.Repository
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly IEnumerable<Participante> _participante;
        public ParticipanteRepository()
        {
            _participante = ObterTodosParticipantes();
        }

        private IEnumerable<Participante> ObterTodosParticipantes()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            IEnumerable<Participante> participantes;
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            var pathRoot = Path.GetPathRoot("lista_pessoas.csv");

            var iconPath = Path.Combine(outPutDirectory, "lista_pessoas.csv");
            using (var reader = new StreamReader("C:/Users/nando/source/repos/Sorteio/Sorteio/Data/Repository/File/lista_pessoas.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                participantes = csv.GetRecords<Participante>().ToList();

            }

            return participantes;
        }

        public IEnumerable<Participante> ObterTodosIdosos()
        {
            return _participante.Where(p => p.Cota == "IDOSO").ToList();
        }

        public IEnumerable<Participante> ObterTodosDeficienteFisicos()
        {
            return _participante.Where(p => p.Cota.Contains("DEFICIENTE")).ToList();
        }

        public IEnumerable<Participante> ObterTodosGeral()
        {
            return _participante.Where(p => p.Cota == "GERAL").ToList();
        }
    }
}
