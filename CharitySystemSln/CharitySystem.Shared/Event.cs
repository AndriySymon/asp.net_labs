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

        [Required(ErrorMessage = "Назва обов'язкова")]
        [StringLength(100, ErrorMessage = "Назва не може бути довшою за 100 символів")]
        [Display(Name = "Назва")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Опис обов'язковий")]
        [StringLength(1000, ErrorMessage = "Опис не може бути довшим за 1000 символів")]
        [Display(Name = "Опис")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Дата є обов'язковою")]
        [Display(Name = "Дата проведення")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Місце обов'язкове")]
        [StringLength(200, ErrorMessage = "Місце не може бути довшим за 200 символів")]
        [Display(Name = "Місце проведення")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Кількість місць обов'язкова")]
        [Range(0, int.MaxValue, ErrorMessage = "Кількість місць має бути додатнім числом")]
        [Display(Name = "Кількість місць")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Мета збору є обов'язковою")]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 1000000, ErrorMessage = "Мета збору має бути додатньою")]
        [Display(Name = "Мета збору")]
        public decimal FundraisingGoal { get; set; }

        [Required(ErrorMessage = "Категорія є обов'язковою")]
        [StringLength(100, ErrorMessage = "Категорія не може бути довшою за 100 символів")]
        [Display(Name = "Категорія")]
        public string Category { get; set; }
    }
}
