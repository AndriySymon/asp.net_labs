using System.ComponentModel.DataAnnotations;

namespace CharitySystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "��'� ����'������")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email ����'�������")]
        [EmailAddress(ErrorMessage = "������� Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "������ ����'�������")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
