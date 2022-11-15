using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class InventoryLevelNotFoundException : NotFoundException
    {
        public InventoryLevelNotFoundException(Guid id) : base($"The inventoryLevel with the identifier {id} was not found.")
        {
        }
    }
}
