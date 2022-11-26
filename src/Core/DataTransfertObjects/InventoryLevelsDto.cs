using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record InventoryLevelsDto
    {
        public Guid? Id { get; set; }
        public int InStock { get; set; }
        public int NewStock { get; set; }
        [Required, BindProperty, DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public Guid ItemId { get; set; }
    }
}