using FluentAssertions;
using NUnit.Framework;
using Sorteio.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorteio.UnitTests.Repository
{
    public class ParticipanteRepositoryUnitTests
    {
        private ParticipanteRepository participanteRepository;

        [SetUp]
        public void Setup()
        {
            participanteRepository = new ParticipanteRepository();
        }

        [Test]
        public void ObterGeralVálidosNaoDeveSerNulo()
        {
            //Arrange

            //Act
            var result = participanteRepository.ObterTodosGeral();
            //Assert
            result.Should().HaveCount(9);
        }

        [Test]
        public void ObterIdososVálidosNaoDeveSerNulo()
        {
            //Arrange

            //Act
            var result = participanteRepository.ObterTodosIdosos();
            //Assert
            result.Should().HaveCount(5);
        }

        [Test]
        public void ObterDeficienteFisicoVálidosNaoDeveSerNulo()
        {
            //Arrange

            //Act
            var result = participanteRepository.ObterTodosDeficienteFisicos();
            //Assert
            result.Should().HaveCount(6);
        }

    }
}
