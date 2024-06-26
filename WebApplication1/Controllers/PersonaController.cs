using Microsoft.AspNetCore.Mvc;
using PersonaTest.Core.Services.Interfaces;
using PersonaTest.Infrastucture.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PersonaTest.API.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService personaService;

        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        [HttpPost]
        public async Task <IActionResult> AddPersona(string firstName, string lastName)
        {
            await personaService.ValidateAndAddAsync(firstName, lastName);
            return Ok($"Unit has been added!");
        }

        [HttpGet]
        public async Task<List<Persona>> GetAllPersonaAsync()
        {
            return await personaService.GetAllSync();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonbyIdAsync(Guid id)
        {
            await personaService.ValidateAndDeleteAsync(id);
            return Ok($"Persona '{id}' has been deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonByIdAsync(Guid id, string firstName,string lastName)
        {
            bool updated = await personaService.ValidateAndUpdateAsync(id, firstName, lastName);
            if (updated)
            {
                return Ok($"Persona '{id}' has been updated to '{firstName} {lastName}'!");
            }
            else
            {
                return NotFound($"Persona '{id}' not found.");
            }
        }

    }
}
