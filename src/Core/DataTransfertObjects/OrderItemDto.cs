namespace DataTransfertObjects
{
    public record OrderItemDto
    {
        public Guid Id { get; set; }
        public int Qte { get; set; }
        public int Total { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }

        public virtual OrdersDto Order { get; set; }

        public virtual ItemsDto Item { get; set; }
    }
}