using Domain;
using MediatR;
using Persistance;
using AutoMapper;

namespace Application.Activities.Commands
{
    public class UpdateActivity : IRequest<string>
    {
        public class Command : IRequest<string>
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, string>
        {
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var existing = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);
                if (existing == null) throw new Exception("Activity not found");


                mapper.Map(request.Activity, existing);
                await context.SaveChangesAsync(cancellationToken);
                return existing.Id;
            }
        }
    }
}
