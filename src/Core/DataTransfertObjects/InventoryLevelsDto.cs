using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record InventoryLevelsDto
    {
        public Guid Id { get; set; }
        public int InStock { get; set; }
        public int NewStock { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        public Guid ItemId { get; set; }
    }
}