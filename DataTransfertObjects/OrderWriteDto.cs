namespace DataTransfertObjects
{
    public record OrderWriteDto
    {
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public string CustomerId { get; set; }
    }
}