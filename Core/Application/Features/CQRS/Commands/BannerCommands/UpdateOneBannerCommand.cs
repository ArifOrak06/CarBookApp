using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForBannerCommands;

namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateOneBannerCommand :  BannerCommandForManipulation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
