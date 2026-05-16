using MediatR;
using Persistance;

namespace Application.InfoItems.Commands
{
    public class DeleteInfoItem : IRequest<Unit>
    {
        public class Command : IRequest<Unit>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Unit>
        {
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await context.InfoItems.FindAsync([request.Id], cancellationToken);
                if (entity == null) throw new Exception("InfoItem not found");

                context.InfoItems.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
