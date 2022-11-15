namespace DataTransfertObjects
{
    public record ItemWriteDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SellerId { get; set; }
        public Guid ItemCategoryId { get; set; }
    }
}