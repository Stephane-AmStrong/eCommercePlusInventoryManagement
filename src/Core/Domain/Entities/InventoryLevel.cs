using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record InventoryLevel
    {
        public Guid Id { get; set; }
        public int InStock { get; set; }
        public int NewStock { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

    }
}
