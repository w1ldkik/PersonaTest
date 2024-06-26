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

        public async Task<List<Persona>> GetAllSync()
        {
            return await unitOfWork.PersonaRepository.GetAllPersonaAsync();
        }

        public async Task ValidateAndDeleteAsync(Guid id)
        {
            await unitOfWork.PersonaRepository.DeletePersonaAsync(GetByIdAsync(id));
        }
        public Persona GetByIdAsync(Guid id)
        {
            return unitOfWork.PersonaRepository.GetPersonaById(id);
        }

        public async Task<bool> ValidateAndUpdateAsync(Guid id, string firstName, string lastName)
        {
            var existingPersona = GetByIdAsync(id);

            if (existingPersona != null)
            {
                
                existingPersona.FirstName = firstName;
                existingPersona.LastName = lastName;

                await unitOfWork.PersonaRepository.UpdatePersonaAsync(existingPersona);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
