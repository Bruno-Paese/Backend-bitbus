using Microsoft.AspNetCore.Mvc;
using POC_Mongo.Src.Domain.Entities;

namespace ItemStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    [HttpGet]
    public async Task<List<Item>> Get() =>
        await (new Item()).getAll();

    [HttpGet("{id}")]
    public async Task<Item> GetOne(string id) =>
        await (new Item()).getOne(id);

    [HttpPost]
    public async Task<IActionResult> save([FromBody] Item item)
    {
        if (await item.save())
        {
            return CreatedAtAction("Save", item);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> update([FromBody] Item item)
    {
        if (await item.update()){ 
            return CreatedAtAction("Update", item);
        }

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> delete([FromBody] Item item)
    {
        if (!await item.delete())
        {
            return BadRequest();
        }
        return Ok();
    }
}