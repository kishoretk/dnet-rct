using System.Collections.Generic;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.InfoItems.Queries
{
    public class GetInfoItemList
    {
        public class Query : IRequest<List<InfoItem>> { }

        public class Handler(AppDbContext context) : IRequestHandler<Query, List<InfoItem>>
        {
            public async Task<List<InfoItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.InfoItems.ToListAsync(cancellationToken);
            }
        }
    }
}
