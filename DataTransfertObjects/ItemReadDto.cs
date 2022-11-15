namespace DataTransfertObjects
{
    public record ItemReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SellerId { get; set; }
        public Guid ItemCategoryId { get; set; }

        public virtual AppUserReadDto Seller { get; set; }

        public virtual ItemCategoryReadDto ItemCategory { get; set; }

        public virtual InventoryLevelsReadDto[] InventoryLevels { get; set; }
        public virtual OrderItemsReadDto[] OrderItems { get; set; }
    }
}