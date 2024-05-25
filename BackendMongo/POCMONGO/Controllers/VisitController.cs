using Microsoft.AspNetCore.Mvc;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace ItemStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await (new Visit()).getAll());
        } catch {
            return StatusCode(500);
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(string id) {
        try {
            return Ok(await (new Visit()).getOne(id));
        } catch {
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> save([FromBody] Visit visit)
    {
        try
        {
            var saveResult = await visit.save();
            if (saveResult)
            {
                return CreatedAtAction("Save", visit);
            }

            return BadRequest();
        } catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> update([FromBody] Visit visit)
    {
        try
        {
            if (await visit.update())
            {
                return CreatedAtAction("Update", visit);
            }
    
            return BadRequest();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateVisitors(string id, [FromBody] Visitor[] visitors)
    {
        try
        {
            Visit visit = new Visit();
            visit = await visit.getOne(id);
        

            visit.visitors = visitors;

            if (await visit.update())
            {
                return CreatedAtAction("Update", visit);
            }

            return BadRequest();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}