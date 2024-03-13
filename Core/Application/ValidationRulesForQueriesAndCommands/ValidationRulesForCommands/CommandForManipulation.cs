using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
    public abstract class CommandForManipulation
    {
        [Required(ErrorMessage ="Id alanı zorunlu bir alandır.")]
        public int Id { get; set; }
        protected CommandForManipulation(int id)
        {
            Id = id;
        }
    }
}
