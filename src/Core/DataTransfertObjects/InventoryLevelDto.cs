namespace DataTransfertObjects
{
    public record InventoryLevelDto
    {
        public Guid? Id { get; set; }
        public int InStock { get; set; }
        public int NewStock { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid ItemId { get; set; }

        public virtual ItemsDto Item { get; set; }
    }
}