using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record Item
    {
        public Item()
        {
            InventoryLevels = new HashSet<InventoryLevel>();
            OrderItems = new HashSet<OrderItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SellerId { get; set; }
        public Guid ItemCategoryId { get; set; }

        //[ForeignKey("SellerId")]
        public virtual AppUser Seller { get; set; }

        //[ForeignKey("ItemCategoryId")]
        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ICollection<InventoryLevel> InventoryLevels { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
