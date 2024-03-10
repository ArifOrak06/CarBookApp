using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries.ProvidedServiceQueries
{
    public class GetOneProvidedServiceByIdQuery : IRequest<GetOneProvidedServiceByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOneProvidedServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
