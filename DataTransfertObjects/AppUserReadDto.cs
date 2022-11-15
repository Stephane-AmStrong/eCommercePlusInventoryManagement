namespace DataTransfertObjects
{
    public record AppUserReadDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ItemsReadDto[] Items { get; set; }
        public virtual OrdersReadDto[] Orders { get; set; }
    }
}