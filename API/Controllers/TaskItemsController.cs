using Domain;
using Application.TaskItems.Commands;
using Application.TaskItems.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TaskItemsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            var items = await Mediator.Send(new GetTaskItemList.Query());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(string id)
        {
            return await Mediator.Send(new GetTaskItemDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTaskItem(TaskItem taskItem)
        {
            var id = await Mediator.Send(new CreateTaskItem.Command { TaskItem = taskItem });
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTaskItem(string id, TaskItem taskItem)
        {
            taskItem.Id = id;
            var updatedId = await Mediator.Send(new UpdateTaskItem.Command { TaskItem = taskItem });
            return Ok(updatedId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskItem(string id)
        {
            await Mediator.Send(new DeleteTaskItem.Command { Id = id });
            return NoContent();
        }
    }
}
