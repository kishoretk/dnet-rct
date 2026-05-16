using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.InfoItems.Commands
{
    public class UpdateInfoItem : IRequest<string>
    {
        public class Command : IRequest<string>
        {
            public required InfoItem InfoItem { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var existing = await context.InfoItems.FindAsync([request.InfoItem.Id], cancellationToken);
                if (existing == null) throw new Exception("InfoItem not found");

                mapper.Map(request.InfoItem, existing);

                await context.SaveChangesAsync(cancellationToken);
                return existing.Id;
            }
        }
    }
}
