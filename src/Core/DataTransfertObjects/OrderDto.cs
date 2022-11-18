namespace DataTransfertObjects
{
    public record OrderDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string CustomerId { get; set; }

        public virtual AppUsersDto Customer { get; set; }
        public virtual OrderItemsDto[] OrderItems { get; set; }
    }
}