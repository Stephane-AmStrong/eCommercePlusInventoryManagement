using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ItemCategoryDuplicateException : DuplicateException
    {
        public ItemCategoryDuplicateException(ItemCategory itemCategory) : base($"An itemCategory named {itemCategory.Name} and description {itemCategory.Description} already exists")
        {
        }
    }
}
