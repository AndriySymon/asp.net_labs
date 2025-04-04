using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharitySystem.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Key]
        public long? EventID { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public string Location { get; set; } = string.Empty;

        public int Capacity { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal FundraisingGoal { get; set; }

        public string Category { get; set; }
    }
}
