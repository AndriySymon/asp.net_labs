using System.ComponentModel.DataAnnotations;

namespace CharitySystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ім'я обов'язкове")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email обов'язковий")]
        [EmailAddress(ErrorMessage = "Невірний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обов'язковий")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
