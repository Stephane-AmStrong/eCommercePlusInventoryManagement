using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataTransfertObjects
{
    public record InventoryLevelDto
    {
        public Guid Id { get; set; }
        public int InStock { get; set; }
        public int NewStock { get; set; }
        [Required, BindProperty, DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid ItemId { get; set; }

        public virtual ItemsDto Item { get; set; }
    }
}