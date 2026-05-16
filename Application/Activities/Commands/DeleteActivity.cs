using MediatR;
using Persistance;

namespace Application.Activities.Commands
{
    public class DeleteActivity : IRequest<Unit>
    {
        public class Command : IRequest<Unit>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Unit>
        {
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await context.Activities.FindAsync([request.Id], cancellationToken);
                if (entity == null) throw new Exception("Activity not found");

                context.Activities.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
