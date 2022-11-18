using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record AppUser
    {
        public AppUser()
        {
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
