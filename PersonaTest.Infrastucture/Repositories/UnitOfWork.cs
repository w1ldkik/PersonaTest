using Microsoft.IdentityModel.Tokens;
using PersonaTest.Infrastucture.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonaTestContext personaTestContext;
        private IPersonaRepository personaRepository;

        public UnitOfWork(PersonaTestContext personaTestContext)
        {
            this.personaTestContext = personaTestContext;
        }
        public IPersonaRepository PersonaRepository
        {
            get
            {
                if (personaRepository == null)
                {
                    personaRepository = new PersonaRepository(personaTestContext);
                }
                return personaRepository;
            }
        }

    }
}
