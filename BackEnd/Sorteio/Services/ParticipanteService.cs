using Sorteio.API.Services.Interface;
using Sorteio.Data.Repository.Interface;
using Sorteio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sorteio.API.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteRepository _participanteRepository;
        public ParticipanteService(IParticipanteRepository participanteRepository)
        {
            _participanteRepository = participanteRepository;
        }
 
        public IEnumerable<Participante> ObterIdososVálidos()
        {
            return ValidarParticipantesElegiveis(_participanteRepository.ObterTodosIdosos());
        }

        public IEnumerable<Participante> ObterDeficienteFisicosValidos()
        {
            return ValidarParticipantesElegiveis(_participanteRepository.ObterTodosDeficienteFisicos());
        }

        
        public IEnumerable<Participante> ObterGeraisValidos()
        {
            return ValidarParticipantesElegiveis(_participanteRepository.ObterTodosGeral());
        }

        public IEnumerable<Participante> RealizarSorteio()
        {
            List<Participante> participantesSorteados = new List<Participante>();

            var idosos = SortearGanhadores(1, ObterIdososVálidos());
            participantesSorteados.AddRange(idosos);

            var deficientesFisico = SortearGanhadores(1, ObterDeficienteFisicosValidos());
            participantesSorteados.AddRange(deficientesFisico);

            var gerais = SortearGanhadores(3, ObterGeraisValidos());
            participantesSorteados.AddRange(gerais);

            return participantesSorteados;
        }

        private IEnumerable<Participante> SortearGanhadores(int quantNumero, IEnumerable<Participante> participantes)
        {
            List<Participante> sorteados = new List<Participante>();
            Random rand = new Random();
            
            for(int i = 0; i < quantNumero; i++)
            {
                int numero = rand.Next(0, participantes.Count());
                var participante = participantes.ElementAt(numero);
                if(!sorteados.Contains(participante))
                {
                    sorteados.Add(participante);
                }
                else
                {
                    quantNumero++;
                }
            }

            return sorteados;
        }

        private IEnumerable<Participante> ValidarParticipantesElegiveis(IEnumerable<Participante> participantes)
        {
            return  participantes.Where(p => (p.Renda >= 1045 && p.Renda <= 5225) && 
                                                                 ValidaCPF(p.CPF) &&
                                            ValidaIdade(p.DataNascimento, p.Cota) &&
                                                         ValidaCID(p.CID, p.Cota));
        }

        private bool ValidaIdade(DateTime dataNascimento, string cota)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade -= 1;
            }

            if (cota == "IDOSO")
            {
                if (idade > 60)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return idade > 15;
            
        }

        private bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool ValidaCID(string cid, string cota)
        {
            if(cota == "DEFICIENTE FÍSICO")
            {
                return !string.IsNullOrEmpty(cid);
            }

            return true;
        }
    }
}
