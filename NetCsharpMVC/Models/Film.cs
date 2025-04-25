using System.ComponentModel.DataAnnotations;

namespace NetCsharpMVC.Models
{
    public class Film
    {
      
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Разрешены только буквы")]

        [Display(Name = "Режиссер")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Разрешены только буквы")]

        [Display(Name = "Жанр")]
        public string Genr { get; set; }
        [Required]
        [Display(Name = "Год")]
        [Range(1895, int.MaxValue, ErrorMessage = "Введите число не меньше 1895")]
        public int Year {  get; set; }
        public string Poster {  get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 500 символов")]
        [Display(Name = "Описание")]
        public string Description { get; set; } 
    }
}
