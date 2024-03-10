using Application.Features.CQRS.Results.FooterAddressResults;
using MediatR;

namespace Application.Features.CQRS.Queries.FooterAddressQueries
{
    public class GetAllFooterAddressQuery : IRequest<List<GetAllFooterAddressesQueryResult>>
    {
    }
}
