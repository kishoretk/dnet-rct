using Domain;
using Application.InfoItems.Commands;
using Application.InfoItems.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InfoItemsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoItem>>> GetInfoItems()
        {
            var items = await Mediator.Send(new GetInfoItemList.Query());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InfoItem>> GetInfoItem(string id)
        {
            return await Mediator.Send(new GetInfoItemDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateInfoItem(InfoItem infoItem)
        {
            var id = await Mediator.Send(new CreateInfoItem.Command { InfoItem = infoItem });
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateInfoItem(string id, InfoItem infoItem)
        {
            infoItem.Id = id;
            var updatedId = await Mediator.Send(new UpdateInfoItem.Command { InfoItem = infoItem });
            return Ok(updatedId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInfoItem(string id)
        {
            await Mediator.Send(new DeleteInfoItem.Command { Id = id });
            return NoContent();
        }
    }
}
