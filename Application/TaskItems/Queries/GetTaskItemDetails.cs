using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.TaskItems.Queries
{
    public class GetTaskItemDetails
    {
        public class Query : IRequest<TaskItem>
        {
            public required string Id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, TaskItem>
        {
            public async Task<TaskItem> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await context.TaskItems.FindAsync([request.Id], cancellationToken);
                if (item == null) throw new Exception("TaskItem not found");
                return item;
            }
        }
    }
}
