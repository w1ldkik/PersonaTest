using Microsoft.AspNetCore.Mvc;
using PersonaTest.Core.Services.Interfaces;
using PersonaTest.Infrastucture.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PersonaTest.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("all")]
        public async Task<List<Persona>> GetAllPersonaAsync()
        {
            return await personaService.GetAllSync();
        }


    }
}
