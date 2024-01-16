using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.Model.Entities;

namespace TesteBancoParana.Repositories.Interfaces
{
    public interface ITelefoneRepository
    {
        List<Telefones> GetAllTelefones(Cliente cliente);

        bool InsertTelefone(Telefones telefone);

        bool UpdateTelefone(Telefones telefone);

        bool DeleteTelefone(Telefones telefones);

        Telefones GetIdTelefone(int id);


    }
}
