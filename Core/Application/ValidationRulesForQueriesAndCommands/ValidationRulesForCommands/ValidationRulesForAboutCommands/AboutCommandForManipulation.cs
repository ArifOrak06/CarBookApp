using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForAboutCommands
{
    public abstract class AboutCommandForManipulation
    {
        [Required(ErrorMessage="Title bilgi girilmesi zorunlu bir alandır.")]
       
        [MaxLength(50,ErrorMessage ="Title en fazla 50 karakter olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Description alanı zorunlu bir alandır.")]
        [MinLength(2, ErrorMessage = "Title en az 2 karakterden oluşturulmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="ImageUrl alanı zorunlu bir alandır")]
        public string ImageUrl { get; set; }
    }
}
