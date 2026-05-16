using Domain;
using MediatR;
using Persistance;

namespace Application.InfoItems.Commands
{
    public class CreateInfoItem : IRequest<string>
    {
        public class Command : IRequest<string>
        {
            public required InfoItem InfoItem { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                context.InfoItems.Add(request.InfoItem);
                await context.SaveChangesAsync(cancellationToken);
                return request.InfoItem.Id;
            }
        }
    }
}
