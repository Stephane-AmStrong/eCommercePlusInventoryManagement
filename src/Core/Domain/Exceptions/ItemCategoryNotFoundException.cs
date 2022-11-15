using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ItemCategoryNotFoundException : NotFoundException
    {
        public ItemCategoryNotFoundException(Guid id) : base($"The itemCategory with the identifier {id} was not found.")
        {
        }
    }
}
