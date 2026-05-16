using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities.Queries;
using Application.Activities.Commands;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            var activities = await Mediator.Send(new GetActivityList.Query());
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            var id = await Mediator.Send(new CreateActivity.Command { Activity = activity });
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateActivity(string id, Activity activity)
        {
            activity.Id = id;
            var updatedId = await Mediator.Send(new UpdateActivity.Command { Activity = activity });
            return Ok(updatedId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command { Id = id });
            return NoContent();
        }
    }
}
