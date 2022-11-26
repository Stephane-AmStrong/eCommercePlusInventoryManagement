using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record OrderItemsDto
    {
        public Guid? Id { get; set; }
        public int Qte { get; set; }
        public int Total { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ItemId { get; set; }
    }
}