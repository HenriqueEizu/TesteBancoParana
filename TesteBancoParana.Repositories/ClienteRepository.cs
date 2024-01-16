using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.DAO;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Repositories.Interfaces;

namespace TesteBancoParana.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private TesteBancoParanaContext testeBancoParanaContext;

        public ClienteRepository(TesteBancoParanaContext context)
        {
            testeBancoParanaContext = context;
        }
        public bool DeleteCliente(Cliente cliente)
        {
            try
            {
                testeBancoParanaContext.Clientes.Remove(cliente);
                testeBancoParanaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }    
            
        }

        public bool DeleteCliente(int id)
        {
            Cliente cli;
            try
            {
                cli = testeBancoParanaContext.Clientes.Where(c=> c.idCliente == id).FirstOrDefault();   
                testeBancoParanaContext.Clientes.Remove(cli);
                testeBancoParanaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClientePorEmail(string email)
        {
            try
            {
                var cli = testeBancoParanaContext.Clientes.Where(c => c.email == email).FirstOrDefault();
                if (cli != null) 
                {
                    testeBancoParanaContext.Clientes.Remove(cli);
                    testeBancoParanaContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> GetAllCliente()
        {
            List<Telefones> lstTel = new List<Telefones>();
            List<Cliente> lstCli = new  List<Cliente>();
            List<Cliente> lstCliResult = new List<Cliente>();
            lstCli = testeBancoParanaContext.Clientes.ToList();
            foreach (Cliente cli in lstCli)
            {
                lstTel = testeBancoParanaContext.Telefones.Where(c=> c.ClienteidCliente == cli.idCliente).ToList();
                cli.telefones = lstTel;
                lstCliResult.Add(cli);
            }
            return lstCliResult;
        }

        public Cliente GetCliente(int id)
        {
            Cliente cliResult = new Cliente();
            cliResult =  testeBancoParanaContext.Clientes.Where(c=> c.idCliente == id).FirstOrDefault();
            if (cliResult != null)
            {
                cliResult.telefones = testeBancoParanaContext.Telefones.Where(c => c.ClienteidCliente == id).ToList();
                return cliResult;
            }
            return null;
        }

        public Cliente GetClientePorDddTelefone(int ddd, int telefone)
        {
            Telefones tel = new Telefones();
            Cliente cliResult = new Cliente();
            List<Telefones> lstTel = new List<Telefones>();

            tel = testeBancoParanaContext.Telefones.Where(c=> c.ddd == ddd & c.numero == telefone).FirstOrDefault();
            if (tel != null) 
            {
                cliResult = testeBancoParanaContext.Clientes.Where(c => c.idCliente == tel.ClienteidCliente).FirstOrDefault();
                if (cliResult != null)
                {
                    lstTel = testeBancoParanaContext.Telefones.Where(c => c.ClienteidCliente == cliResult.idCliente).ToList();
                    cliResult.telefones = lstTel;
                    return cliResult;
                }
                    
            }
            return null;
        }

        public Cliente GetClientePorEmail(string email)
        {
            var cli = testeBancoParanaContext.Clientes.Where(c => c.email == email).FirstOrDefault();
            return cli;
        }

        public bool InsertCliente(Cliente cliente)
        {
            try
            {
                testeBancoParanaContext.Clientes.Add(cliente);
                testeBancoParanaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCliente(Cliente cliente)
        {
            try
            {
                testeBancoParanaContext.Entry(cliente).State = EntityState.Modified;
                testeBancoParanaContext.SaveChanges();
                foreach(Telefones tel in cliente.telefones)
                {
                    if (tel.idTelefone == 0)
                    {
                        testeBancoParanaContext.Add(tel);
                        testeBancoParanaContext.SaveChanges();
                    }
                    else
                    {
                        testeBancoParanaContext.Entry(tel).State = EntityState.Modified;
                        testeBancoParanaContext.SaveChanges();
                    }
                    
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
