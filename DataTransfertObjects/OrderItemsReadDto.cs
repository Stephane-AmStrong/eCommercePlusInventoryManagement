namespace DataTransfertObjects
{
    public record OrderItemsReadDto
    {
        public Guid Id { get; set; }
        public int Qte { get; set; }
        public int Total { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }

        public virtual OrdersReadDto Order { get; set; }

        public virtual ItemsReadDto Item { get; set; }
    }
}