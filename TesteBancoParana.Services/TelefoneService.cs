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
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _repository;
        public TelefoneService(ITelefoneRepository repository)
        {
            _repository = repository;
        }

        public bool DeleteTelefone(Telefones telefones)
        {
            throw new NotImplementedException();
        }

        public List<Telefones> GetAllTelefones(Cliente cliente)
        {
            return _repository.GetAllTelefones(cliente);
        }

        public Telefones GetIdTelefone(int id)
        {
            return _repository.GetIdTelefone(id);
        }

        public bool InsertTelefone(Telefones telefone)
        {
            return _repository.InsertTelefone(telefone);
        }

        public bool UpdateTelefone(Telefones telefone)
        {
            throw new NotImplementedException();
        }
    }
}
