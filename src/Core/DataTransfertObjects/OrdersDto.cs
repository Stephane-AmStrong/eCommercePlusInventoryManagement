using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record OrdersDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}