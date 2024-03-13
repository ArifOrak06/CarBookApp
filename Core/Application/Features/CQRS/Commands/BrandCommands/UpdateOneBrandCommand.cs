using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForBrandCommands;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class UpdateOneBrandCommand :  BrandCommandForManipulation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
