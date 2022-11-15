namespace DataTransfertObjects
{
    public record OrderItemReadDto
    {
        public Guid Id { get; set; }
        public int Qte { get; set; }
        public int Total { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }

        public virtual OrderReadDto Order { get; set; }

        public virtual ItemReadDto Item { get; set; }
    }
}