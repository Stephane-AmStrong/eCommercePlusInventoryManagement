using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record AppUserDto
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; } = DateTime.Now;

        public virtual ItemsDto[] Items { get; set; }
        public virtual OrdersDto[] Orders { get; set; }
    }
}