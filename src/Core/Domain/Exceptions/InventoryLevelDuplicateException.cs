using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class InventoryLevelDuplicateException : DuplicateException
    {
        public InventoryLevelDuplicateException(InventoryLevel inventoryLevel) : base($"An inventoryLevel with {inventoryLevel.InStock}, {inventoryLevel.NewStock}, {inventoryLevel.ItemId} and UpdatedAt {inventoryLevel.UpdatedAt} already exists")
        {
        }
    }
}
