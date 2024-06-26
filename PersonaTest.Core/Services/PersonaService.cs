using PersonaTest.Core.Services.Interfaces;
using PersonaTest.Infrastucture.Models;
using PersonaTest.Infrastucture.Repositories;
using PersonaTest.Infrastucture.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task ValidateAndAddAsync(string firstName, string lastName)
        {
            var persona = new Persona
            {
               FirstName = firstName, LastName = lastName
            };
            await unitOfWork.PersonaRepository.AddPersonaAsync(persona);
        }
    }
}
