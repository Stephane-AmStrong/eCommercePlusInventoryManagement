using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException(Guid id) : base($"The item with the identifier {id} was not found.")
        {
        }
    }
}
