namespace DataTransfertObjects
{
    public record InventoryLevelsReadDto
    {
        public Guid Id { get; set; }
        public int InStock { get; set; }
        public int NewStock { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid ItemId { get; set; }
    }
}