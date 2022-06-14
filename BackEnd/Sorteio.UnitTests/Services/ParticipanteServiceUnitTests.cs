using FluentAssertions;
using Moq;
using NUnit.Framework;
using Sorteio.API.Services;
using Sorteio.Data.Repository.Interface;
using Sorteio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.UnitTests.Services
{
    public class ParticipanteServiceUnitTests
    {
        private ParticipanteService participanteService;
        private Mock<IParticipanteRepository> _participanteRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _participanteRepositoryMock = new Mock<IParticipanteRepository>();
            participanteService = new ParticipanteService(_participanteRepositoryMock.Object);
        }

        [Test]
        public void ObterGeralVálidosNaoDeveSerNulo()
        {
            //Arrange
            _participanteRepositoryMock.Setup(p => p.ObterTodosGeral())
                .Returns(ObterParticipantesGeral());
            //Act
            var result = participanteService.ObterGeraisValidos();
            //Assert
            result.Should().HaveCount(5);
        }

        [Test]
        public void ObterIdososVálidosNaoDeveSerNulo()
        {
            //Arrange
            _participanteRepositoryMock.Setup(p => p.ObterTodosIdosos())
                .Returns(ObterParticipantesIdosos());
            //Act
            var result = participanteService.ObterIdososVálidos();
            //Assert
            result.Should().HaveCount(3);
        }

        [Test]
        public void ObterDeficienteFisicoVálidosNaoDeveSerNulo()
        {
            //Arrange
            _participanteRepositoryMock.Setup(p => p.ObterTodosDeficienteFisicos())
                .Returns(ObterParticipantesComDeficienciaFisica());
            //Act
            var result = participanteService.ObterDeficienteFisicosValidos();
            //Assert
            result.Should().HaveCount(2);
        }

        [Test]
        public void RealizarSorteioNaoDeveSerNulo()
        {
            //Arrange
            _participanteRepositoryMock.Setup(p => p.ObterTodosDeficienteFisicos())
                .Returns(ObterParticipantesComDeficienciaFisica());
            _participanteRepositoryMock.Setup(p => p.ObterTodosIdosos())
              .Returns(ObterParticipantesIdosos());
            _participanteRepositoryMock.Setup(p => p.ObterTodosGeral())
               .Returns(ObterParticipantesGeral());

            //Act
            var result = participanteService.RealizarSorteio();
            var idososSorteados = result.Where(i => i.Cota == "IDOSO");
            var geraisSorteados = result.Where(i => i.Cota == "GERAL");
            var deficienteSorteados = result.Where(i => i.Cota.Contains("DEFICIENTE"));

            //Assert
            result.Should().HaveCount(5);
            idososSorteados.Should().HaveCount(1);
            geraisSorteados.Should().HaveCount(3);
            deficienteSorteados.Should().HaveCount(1);
        }

        private IEnumerable<Participante> ObterParticipantesGeral()
        {
            return new List<Participante>()
            {
                new Participante
                {
                    Nome = "TesteValido",
                    DataNascimento = new DateTime(1980,12,15),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteValido2",
                    DataNascimento = new DateTime(1980,12,15),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteValido3",
                    DataNascimento = new DateTime(1980,12,15),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteValido4",
                    DataNascimento = new DateTime(1980,12,15),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteValido5",
                    DataNascimento = new DateTime(1980,12,15),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteIdadeInvalida",
                    DataNascimento = new DateTime(2010,1,22),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                 new Participante
                {
                    Nome = "TesteCpfInvalido",
                    DataNascimento = new DateTime(2010,1,22),
                    CID = string.Empty,
                    Cota = "GERAL",
                    Renda = 2000,
                    CPF = "123.456.789-00"
                },

            };
        }

        private IEnumerable<Participante> ObterParticipantesIdosos()
        {
            return new List<Participante>()
            {
                new Participante
                {
                    Nome = "TesteValido",
                    DataNascimento = new DateTime(1960,12,15),
                    CID = string.Empty,
                    Cota = "IDOSO",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteValido2",
                    DataNascimento = new DateTime(1958,12,15),
                    CID = string.Empty,
                    Cota = "IDOSO",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteValido3",
                    DataNascimento = new DateTime(1950,12,15),
                    CID = string.Empty,
                    Cota = "IDOSO",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteIdadeInvalida",
                    DataNascimento = new DateTime(1970,1,22),
                    CID = string.Empty,
                    Cota = "IDOSO",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                 new Participante
                {
                    Nome = "TesteCpfInvalido",
                    DataNascimento = new DateTime(1960,1,22),
                    CID = string.Empty,
                    Cota = "IDOSO",
                    Renda = 2000,
                    CPF = "123.456.789-00"
                },

            };
        }

        private IEnumerable<Participante> ObterParticipantesComDeficienciaFisica()
        {
            return new List<Participante>()
            {
                new Participante
                {
                    Nome = "TesteValido",
                    DataNascimento = new DateTime(1960,12,15),
                    CID = "H90",
                    Cota = "DEFICIENTE FÍSICO",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                new Participante
                {
                    Nome = "TesteIdadeInvalida",
                    DataNascimento = new DateTime(1970,1,22),
                    CID = "H90",
                    Cota = "DEFICIENTE FÍSICO",
                    Renda = 2000,
                    CPF = "969.666.535-00"
                },
                 new Participante
                {
                    Nome = "TesteCpfInvalido",
                    DataNascimento = new DateTime(1960,1,22),
                    CID = "H90",
                    Cota = "DEFICIENTE FÍSICO",
                    Renda = 2000,
                    CPF = "123.456.789-00"
                },
                 new Participante
                {
                    Nome = "TesteCIDInvalido",
                    DataNascimento = new DateTime(1960,1,22),
                    CID = string.Empty,
                    Cota = "DEFICIENTE FÍSICO",
                    Renda = 2000,
                    CPF = "123.456.789-00"
                },

            };
        }
    }
}
