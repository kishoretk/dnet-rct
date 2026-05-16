using MediatR;
using Persistance;

namespace Application.TaskItems.Commands
{
    public class DeleteTaskItem : IRequest<Unit>
    {
        public class Command : IRequest<Unit>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Unit>
        {
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await context.TaskItems.FindAsync([request.Id], cancellationToken);
                if (entity == null) throw new Exception("TaskItem not found");

                context.TaskItems.Remove(entity);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
