using System.ComponentModel.DataAnnotations;

namespace CharitySystem.Models
{
    public class DonationModel
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Введіть суму більше 0")]
        public decimal Amount { get; set; }
    }
}