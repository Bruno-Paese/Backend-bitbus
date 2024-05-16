using Microsoft.AspNetCore.Mvc;
using POCMONGO.Domain.Entities;

namespace ItemStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitController : ControllerBase
{
    [HttpGet]
    public async Task<List<Visit>> Get() =>
        await (new Visit()).getAll();

    [HttpGet("{id}")]
    public async Task<Visit> GetOne(string id) =>
        await (new Visit()).getOne(id);

    [HttpPost]
    public async Task<IActionResult> save([FromBody] Visit visit)
    {
        if (await visit.save())
        {
            return CreatedAtAction("Save", visit);
        }

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> update([FromBody] Visit visit)
    {
        if (await visit.update())
        {
            return CreatedAtAction("Update", visit);
        }

        return BadRequest();
    }
}