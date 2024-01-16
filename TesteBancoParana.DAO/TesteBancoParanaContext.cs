using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBancoParana.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace TesteBancoParana.DAO
{
    public class TesteBancoParanaContext : DbContext
    {

        public TesteBancoParanaContext(DbContextOptions<TesteBancoParanaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = null!;

        public DbSet<Telefones> Telefones { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost\\sql2019,1433;Database=TesteBancoParana;User ID=sa;Password=pr0d@p123;Trusted_Connection=False; TrustServerCertificate=True;").
            UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

    }
}
