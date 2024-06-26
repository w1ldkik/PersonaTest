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
    }
}
