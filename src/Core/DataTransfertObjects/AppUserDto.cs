namespace DataTransfertObjects
{
    public record AppUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ItemsDto[] Items { get; set; }
        public virtual OrdersDto[] Orders { get; set; }
    }
}