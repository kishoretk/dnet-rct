using Domain;
using MediatR;
using Persistance;

namespace Application.TaskItems.Commands
{
    public class CreateTaskItem : IRequest<string>
    {
        public class Command : IRequest<string>
        {
            public required TaskItem TaskItem { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.TaskItem.DateAdded == default)
                {
                    request.TaskItem.DateAdded = DateTime.UtcNow;
                }

                context.TaskItems.Add(request.TaskItem);
                await context.SaveChangesAsync(cancellationToken);
                return request.TaskItem.Id;
            }
        }
    }
}
