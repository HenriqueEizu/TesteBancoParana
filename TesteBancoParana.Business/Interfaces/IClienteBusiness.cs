using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.Model.Entities;

namespace TesteBancoParana.Business.Interfaces
{
    public interface IClienteBusiness
    {
        bool AddCliente(Cliente cliente);

        bool UpdateCliente(Cliente cliente);

        bool DeleteCliente(int id);

        Cliente GetCliente(int id);

        List<Cliente> GetAllCliente();

        Cliente GetClientePorDddTelefone(int ddd, int telefone);

        bool DeleteClientePorEmail(string email);

        Cliente GetClientePorEmail(string email);

    }
}
