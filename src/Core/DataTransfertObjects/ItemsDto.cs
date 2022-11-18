using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record ItemsDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string SellerId { get; set; }
        [Required]
        public Guid ItemCategoryId { get; set; }
    }
}