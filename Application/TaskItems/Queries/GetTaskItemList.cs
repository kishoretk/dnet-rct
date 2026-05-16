using System.Collections.Generic;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.TaskItems.Queries
{
    public class GetTaskItemList
    {
        public class Query : IRequest<List<TaskItem>> { }

        public class Handler(AppDbContext context) : IRequestHandler<Query, List<TaskItem>>
        {
            public async Task<List<TaskItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.TaskItems.ToListAsync(cancellationToken);
            }
        }
    }
}
