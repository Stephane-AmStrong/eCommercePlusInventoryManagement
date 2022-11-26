using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record ItemCategoryDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ItemsDto[] Items { get; set; }
    }
}