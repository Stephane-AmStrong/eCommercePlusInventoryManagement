using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class AppUserNotFoundException : NotFoundException
    {
        public AppUserNotFoundException(Guid id) : base($"The appUser with the identifier {id} was not found.")
        {
        }
        public AppUserNotFoundException(string id) : base($"The appUser with the identifier {id} was not found.")
        {
        }
    }
}
