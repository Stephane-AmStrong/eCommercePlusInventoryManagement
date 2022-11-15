namespace DataTransfertObjects
{
    public record AppUserWriteDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

    }
}