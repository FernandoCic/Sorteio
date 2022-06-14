using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorteio.Entities
{
    public class Participante
    {
        //public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        [Name("Data Nascimento")]
        [Format("d/M/yyyy")]
        public DateTime DataNascimento { get; set; }
        public decimal Renda { get; set; }
        public string Cota { get; set; }
        public string CID { get; set; }
    }
}
