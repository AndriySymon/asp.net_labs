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

        [Required(ErrorMessage = "����� ����'������")]
        [StringLength(100, ErrorMessage = "����� �� ���� ���� ������ �� 100 �������")]
        [Display(Name = "�����")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "���� ����'�������")]
        [StringLength(1000, ErrorMessage = "���� �� ���� ���� ������ �� 1000 �������")]
        [Display(Name = "����")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "���� � ����'�������")]
        [Display(Name = "���� ����������")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "̳��� ����'������")]
        [StringLength(200, ErrorMessage = "̳��� �� ���� ���� ������ �� 200 �������")]
        [Display(Name = "̳��� ����������")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "ʳ������ ���� ����'������")]
        [Range(0, int.MaxValue, ErrorMessage = "ʳ������ ���� �� ���� ������� ������")]
        [Display(Name = "ʳ������ ����")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "���� ����� � ����'�������")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 1000000, ErrorMessage = "���� ����� �� ���� ���������")]
        [Display(Name = "���� �����")]
        public decimal FundraisingGoal { get; set; }

        [Required(ErrorMessage = "�������� � ����'�������")]
        [StringLength(100, ErrorMessage = "�������� �� ���� ���� ������ �� 100 �������")]
        [Display(Name = "��������")]
        public string Category { get; set; }
    }
}
