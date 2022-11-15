using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record ItemCategory
    {
        public ItemCategory()
        {
            Items = new HashSet<Item>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
