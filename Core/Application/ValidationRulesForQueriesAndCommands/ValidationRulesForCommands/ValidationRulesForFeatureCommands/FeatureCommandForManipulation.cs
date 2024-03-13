using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForFeatureCommands
{
    public abstract class FeatureCommandForManipulation
    {
        [Required(ErrorMessage ="Name alanı bilgi girilmesi zorunlu bir alandır.")]
        [MinLength(3,ErrorMessage ="Name alanı minimum 3 karakterden oluşturulmalıdır.")]
        public string Name { get; set; }
    }
}
