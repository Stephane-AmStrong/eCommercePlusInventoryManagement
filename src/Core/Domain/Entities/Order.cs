using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string CustomerId { get; set; }

        //[ForeignKey("CustomerId")]
        public virtual AppUser Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
