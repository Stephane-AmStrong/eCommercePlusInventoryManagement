namespace DataTransfertObjects
{
    public record OrdersReadDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string CustomerId { get; set; }

        public virtual AppUsersReadDto Customer { get; set; }
    }
}