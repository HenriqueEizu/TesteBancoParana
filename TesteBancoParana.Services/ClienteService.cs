using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Repositories.Interfaces;
using TesteBancoParana.Services.Interfaces;

namespace TesteBancoParana.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public bool DeleteCliente(int id)
        {
            return _repository.DeleteCliente(id);
        }

        public bool DeleteClientePorEmail(string email)
        {
            return _repository.DeleteClientePorEmail(email);
        }

        public List<Cliente> GetAllCliente()
        {
            var ttt = _repository.GetAllCliente();
            return ttt.ToList();
        }

        public Cliente GetCliente(int id)
        {
            return _repository.GetCliente(id);
        }

        public Cliente GetClientePorDddTelefone(int ddd, int telefone)
        {
            return _repository.GetClientePorDddTelefone(ddd,telefone);
        }

        public Cliente GetClientePorEmail(string email)
        {
            return _repository.GetClientePorEmail(email);
        }

        public bool InsertCliente(Cliente cliente)
        {
            return _repository.InsertCliente(cliente);
        }

        public bool UpdateCliente(Cliente cliente)
        {
            return _repository.UpdateCliente(cliente);
        }
    }
}
