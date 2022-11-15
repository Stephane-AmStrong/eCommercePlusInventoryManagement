namespace DataTransfertObjects
{
    public record AppUsersReadDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }


    }
}