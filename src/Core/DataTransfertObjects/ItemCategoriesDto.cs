using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record ItemCategoriesDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}