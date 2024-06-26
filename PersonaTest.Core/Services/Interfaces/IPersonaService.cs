using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest.Core.Services.Interfaces
{
    public interface IPersonaService
    {
        Task ValidateAndAddAsync(string firstName,string lastName);
    }
}
