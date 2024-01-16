using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteBancoParana.Business;
using TesteBancoParana.Business.Interfaces;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Services.Interfaces;

namespace TesteBancoParana.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly ITelefoneService _serviceTelefone;
        ClienteBusiness clienteBusiness;

        public ClientController(IClienteService service, ITelefoneService serviceTelefone)
        {
            _service = service;
            _serviceTelefone = serviceTelefone;
        }

        [HttpPost("insertCliente")]
        [Authorize]
        public bool InsertCliente(Cliente cliente)
        {
            try
            {
                clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
                clienteBusiness.AddCliente(cliente);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        [HttpPost("updateCliente")]
        [Authorize]
        public bool UpdateCliente(Cliente cliente)
        {
            try
            {
                clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
                clienteBusiness.UpdateCliente(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        [HttpPost("deleteCliente")]
        [Authorize]
        public bool DeleteCliente(int id)
        {
            try
            {
                clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
                clienteBusiness.DeleteCliente(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        [HttpPost("deleteClientePorEmail")]
        [Authorize]
        public bool DeleteClientePorEmail(string email)
        {
            try
            {
                clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
                clienteBusiness.DeleteClientePorEmail(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        [HttpGet("GetAllCliente")]
        [Authorize]
        public List<Cliente> GetAllCliente()
        {
            clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
            var lstCli = clienteBusiness.GetAllCliente();
            return lstCli;
        }

        [HttpGet("GetCliente")]
        [Authorize]
        public Cliente GetCliente(int id)
        {
            clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
            var cli  = clienteBusiness.GetCliente(id);
            return cli;
        }

        [HttpGet("GetClientePorDddTelefone")]
        [Authorize]
        public Cliente GetClientePorDddTelefone(int ddd, int telefone)
        {
            clienteBusiness = new ClienteBusiness(_service, _serviceTelefone);
            var cli = clienteBusiness.GetClientePorDddTelefone(ddd,telefone);
            return cli;
        }
    }
}
