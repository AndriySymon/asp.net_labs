using System.ComponentModel.DataAnnotations;

namespace CharitySystem.Models.ViewModels
{
    public class EditProfileViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }

        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
    }
}

