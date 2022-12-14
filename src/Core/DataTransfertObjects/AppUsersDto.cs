using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record AppUsersDto
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}