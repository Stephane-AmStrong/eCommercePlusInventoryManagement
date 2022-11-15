namespace DataTransfertObjects
{
    public record OrderReadDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string CustomerId { get; set; }

        public virtual AppUserReadDto Customer { get; set; }
        public virtual OrderItemsReadDto[] OrderItems { get; set; }
    }
}