using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TesteBancoParana.Business.Interfaces;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Services.Interfaces;

namespace TesteBancoParana.Business
{
    public class ClienteBusiness : IClienteBusiness
    {

        private readonly IClienteService _service;
        private readonly ITelefoneService _serviceTelefone;
        public ClienteBusiness(IClienteService service, ITelefoneService serviceTelefone) 
        {
            _service = service;
            _serviceTelefone = serviceTelefone;
        }
        public bool AddCliente(Cliente cliente)
        {
            try
            {
                if (cliente.nomeCliente == null || cliente.nomeCliente == "")
                {
                    throw new Exception("Nome do cliente não pode ser nulo ou vazio");
                }

                MailAddress m = new MailAddress(cliente.email);

                var values = Enum.GetValues<EnumTipoTelefone>();

                foreach (Telefones tel in cliente.telefones)
                {
                    if (!values.Contains(tel.tipoTelefone))
                    {
                        throw new Exception("Tipo de telefone inexistente");
                    }
                }
                _service.InsertCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool DeleteCliente(int id)
        {
            Cliente cli;
            cli = _service.GetCliente(id);

            return _service.DeleteCliente(id);
        }

        public bool DeleteClientePorEmail(string email)
        {
            var cli = GetClientePorEmail(email);

            return _service.DeleteClientePorEmail(email);
        }

        public List<Cliente> GetAllCliente()
        {
            return _service.GetAllCliente();
        }

        public Cliente GetCliente(int id)
        {
            Cliente cli;
            cli = _service.GetCliente(id);

            return _service.GetCliente(id);
        }

        public Cliente GetClientePorDddTelefone(int ddd, int telefone)
        {
            Cliente cli = _service.GetClientePorDddTelefone(ddd, telefone);
            return cli;
        }

        public Cliente GetClientePorEmail(string email)
        {
            return _service.GetClientePorEmail(email);
        }

        public bool UpdateCliente(Cliente cliente)
        {
            Cliente cli;
            Telefones telAux = null;
            try
            {
                cli = _service.GetCliente(cliente.idCliente);

                if (cli == null)
                    throw new InvalidOperationException("Cliente inexistente");

                bool existeEmail = _service.GetAllCliente().Where(c => c.email == cliente.email & c.idCliente != cliente.idCliente).Count() > 0;

                if (existeEmail)
                {
                    throw new Exception("Email ja existente nos nosso cadastros");
                }
                MailAddress m = new MailAddress(cliente.email);

                foreach(Telefones tel in cliente.telefones)
                {
                    if (tel.idTelefone != 0) // Telefone novo no Update
                        telAux = _serviceTelefone.GetIdTelefone(tel.idTelefone);

                    if (telAux == null && tel.idTelefone != 0)
                    {
                        throw new InvalidOperationException("Telefone inexistente");
                    }
                    else
                    {
                        if (tel.idTelefone != 0)
                        {
                            var telCli = telAux.ClienteidCliente == tel.ClienteidCliente;

                            if (!telCli)
                                throw new InvalidOperationException("Telefone não pertence a este cliente");
                        }

                        var values = Enum.GetValues<EnumTipoTelefone>();

                        if (!values.Contains(tel.tipoTelefone))
                        {
                            throw new Exception("Tipo de telefone inexistente");
                        }
                    }
                }

                _service.UpdateCliente(cliente);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
            return true;
        }
    }
}
