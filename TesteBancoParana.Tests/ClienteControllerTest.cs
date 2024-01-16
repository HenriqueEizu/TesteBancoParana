using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.Business;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Repositories.Interfaces;
using TesteBancoParana.Services.Interfaces;
using TesteBancoParana.WebApi.Controllers;

namespace TesteBancoParana.Tests
{
    [TestClass]
    public class ClienteControllerTest
    {
        private Mock<IClienteService> _service;
        private Mock<ITelefoneService> _serviceTelefone;
        private Mock<IClienteRepository> _clienteRepository;
        private Mock<ITelefoneRepository> _telefoneRepository;
        ClienteBusiness clienteBusiness;
        private Fixture _fixture;
        private ClientController _controllerCliente;

        public ClienteControllerTest()
        {
            _fixture = new Fixture();
            _service = new Mock<IClienteService>();
            _serviceTelefone = new Mock<ITelefoneService>();
            _clienteRepository = new Mock<IClienteRepository>();
            _telefoneRepository = new Mock<ITelefoneRepository>();
        }

        [TestMethod]
        public void AdquirindoTodosCliente_Teste()
        {
           
            _controllerCliente = new ClientController(_service.Object, _serviceTelefone.Object);

            var result = _controllerCliente.GetAllCliente();

            Assert.AreEqual(null, result);

        }

        [TestMethod]
        public void InserindoCliente_Teste()
        {
            Cliente cli = new Cliente();
            Telefones tel = new Telefones();
            List<Telefones> listTel = new List<Telefones>();


            cli.nomeCliente = "Henrique Eizu";
            cli.email = "henriqueEizu@ggg.com";

            tel.ddd = 11;
            tel.numero = 969751971;
            tel.tipoTelefone = EnumTipoTelefone.Celular;
            listTel.Add(tel);

            tel.ddd = 11;
            tel.numero = 50611692;
            tel.tipoTelefone = EnumTipoTelefone.Fixo;
            listTel.Add(tel);

            cli.telefones = listTel;
            _controllerCliente = new ClientController(_service.Object, _serviceTelefone.Object);

            var result = _controllerCliente.InsertCliente(cli);

            Assert.AreEqual(true, result);
        }

        [TestMethod]

        public void BuscandoClinte_Teste()
        {
            _controllerCliente = new ClientController(_service.Object, _serviceTelefone.Object);

            var result = _controllerCliente.GetCliente(1);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void BuscandoClientePorDddTelefone_Teste()
        {
            _controllerCliente = new ClientController(_service.Object, _serviceTelefone.Object);

            var result = _controllerCliente.GetClientePorDddTelefone(11,912345678);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void ExcluindoCliente_Teste()
        {
            _controllerCliente = new ClientController(_service.Object, _serviceTelefone.Object);

            var result = _controllerCliente.DeleteCliente(1);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ExcluindoClientePorEmail_Teste()
        {
            _controllerCliente = new ClientController(_service.Object, _serviceTelefone.Object);

            var result = _controllerCliente.DeleteClientePorEmail("teste@teste.com");

            Assert.AreEqual(true, result);
        }
        
    }
}
