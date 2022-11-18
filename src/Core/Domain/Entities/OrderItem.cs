using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record OrderItem
    {
        public Guid Id { get; set; }
        public int Qte { get; set; }
        public int Total { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ItemId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }
    }
}
