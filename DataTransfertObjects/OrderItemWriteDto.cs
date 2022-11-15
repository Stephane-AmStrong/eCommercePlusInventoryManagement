namespace DataTransfertObjects
{
    public record OrderItemWriteDto
    {
        public int Qte { get; set; }
        public int Total { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
    }
}