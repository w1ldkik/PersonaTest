using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaTest.Infrastucture.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IPersonaRepository PersonaRepository { get; }
    }
}
