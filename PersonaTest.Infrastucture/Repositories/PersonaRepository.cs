using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PersonaTest.Infrastucture.Models;
using PersonaTest.Infrastucture.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest.Infrastucture.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaTestContext personaTestContext;
        public PersonaRepository(PersonaTestContext personaTestContext)
        {
            this.personaTestContext = personaTestContext;
        }

        public async Task AddPersonaAsync(Persona persona)
        {
            await personaTestContext.Persons.AddAsync(persona);
            await personaTestContext.SaveChangesAsync();
        }

        public async Task<List<Persona>> GetAllPersonaAsync()
        {
            return await personaTestContext.Persons.Select(x => x).ToListAsync();
        }

        public Persona GetPersonaById(Guid id)
        {
            return  personaTestContext.Persons.Where(x => x.Id == id).FirstOrDefault();
            
        }

        public async Task DeletePersonaAsync(Persona persona)
        {
            personaTestContext.Remove(persona);
            await personaTestContext.SaveChangesAsync();
        }
    }
}
