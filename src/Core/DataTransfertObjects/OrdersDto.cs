using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record OrdersDto
    {
        public Guid? Id { get; set; }
        [Required,BindProperty, DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        public int Total { get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}