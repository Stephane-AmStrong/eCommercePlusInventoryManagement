using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ItemDuplicateException : DuplicateException
    {
        public ItemDuplicateException(Item item) : base($"An item with name : {item.Name}, description : {item.Description}, belonging to seller with id : {item.SellerId} already exists")
        {
        }
    }
}
