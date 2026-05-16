using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.InfoItems.Queries
{
    public class GetInfoItemDetails
    {
        public class Query : IRequest<InfoItem>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, InfoItem>
        {
            public async Task<InfoItem> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await context.InfoItems.FindAsync([request.Id], cancellationToken);
                if (item == null) throw new Exception("InfoItem not found");
                return item;
            }
        }
    }
}
