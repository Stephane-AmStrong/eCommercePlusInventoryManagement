namespace DataTransfertObjects
{
    public record ItemsReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SellerId { get; set; }
        public Guid ItemCategoryId { get; set; }

        public virtual AppUsersReadDto Seller { get; set; }

        public virtual ItemCategoriesReadDto ItemCategory { get; set; }

    }
}