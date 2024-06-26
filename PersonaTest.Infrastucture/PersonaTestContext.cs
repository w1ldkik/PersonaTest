using Microsoft.EntityFrameworkCore;
using PersonaTest.Infrastucture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest.Infrastucture
{
    public class PersonaTestContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=PersonaDatabase;Trusted_Connection=True;";

        public PersonaTestContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Persona> Persons { get; set; }
    }
}
