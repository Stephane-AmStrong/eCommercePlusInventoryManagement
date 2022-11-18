using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record ItemDto
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string SellerId { get; set; }
        [Required]
        public Guid ItemCategoryId { get; set; }

        public virtual AppUsersDto Seller { get; set; }

        public virtual ItemCategoriesDto ItemCategory { get; set; }

        public virtual InventoryLevelsDto[] InventoryLevels { get; set; }
        public virtual OrderItemsDto[] OrderItems { get; set; }
    }
}