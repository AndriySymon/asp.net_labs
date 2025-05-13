using System.ComponentModel.DataAnnotations;

namespace CharitySystem.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль має містити щонайменше {2} символів.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Пароль має містити принаймні одну велику літеру, одну маленьку літеру та одну цифру.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Пароль і його підтвердження не співпадають.")]
        public string ConfirmPassword { get; set; }
    }
}
