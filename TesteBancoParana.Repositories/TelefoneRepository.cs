using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.DAO;
using TesteBancoParana.Model.Entities;
using TesteBancoParana.Repositories.Interfaces;

namespace TesteBancoParana.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private TesteBancoParanaContext testeBancoParanaContext;

        public TelefoneRepository(TesteBancoParanaContext context)
        {
            testeBancoParanaContext = context;
        }

        public bool DeleteTelefone(Telefones telefones)
        {
            try
            {
                testeBancoParanaContext.Telefones.Remove(telefones);
                testeBancoParanaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Telefones> GetAllTelefones(Cliente cliente)
        {
            return testeBancoParanaContext.Telefones.Where(c=> c.ClienteidCliente == cliente.idCliente).ToList();
        }

        public Telefones GetIdTelefone(int id)
        {
            Telefones result =  testeBancoParanaContext.Telefones.Where(c => c.idTelefone == id).FirstOrDefault();
            if (result == null)
                throw new InvalidOperationException("Telefone não encontrado");
            else
                return result;

        }

        public bool InsertTelefone(Telefones telefone)
        {
            try
            {
                testeBancoParanaContext.Telefones.Add(telefone);
                testeBancoParanaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTelefone(Telefones telefone)
        {
            try
            {
                testeBancoParanaContext.Entry(telefone).State = EntityState.Modified;
                testeBancoParanaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
