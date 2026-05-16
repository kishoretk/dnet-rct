using AutoMapper;
using Domain;
using MediatR;
using Persistance;

namespace Application.TaskItems.Commands
{
    public class UpdateTaskItem : IRequest<string>
    {
        public class Command : IRequest<string>
        {
            public required TaskItem TaskItem { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var existing = await context.TaskItems.FindAsync([request.TaskItem.Id], cancellationToken);
                if (existing == null) throw new Exception("TaskItem not found");

                mapper.Map(request.TaskItem, existing);

                await context.SaveChangesAsync(cancellationToken);
                return existing.Id;
            }
        }
    }
}
