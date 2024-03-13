using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForCategoryCommands
{
    public abstract class CategoryCommandForManipulation
    {
        [Required(ErrorMessage ="Description alanı bilgi birilmesi zorunlu bir alandır.")]
        public string Description { get; set; }
    }
}
