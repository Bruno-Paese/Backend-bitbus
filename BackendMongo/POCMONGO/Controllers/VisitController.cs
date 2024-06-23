using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;
using POCMONGO.Controllers.Filter;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace ItemStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitController : ControllerBase
{
    private const bool ALLOW_SAME_NAME = true;

    private readonly VisitValidator _validator = new VisitValidator();
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] VisitFilter? filter)
    {
        try
        {
            var result = await (new Visit()).getAll(filter);
            return Ok(result);
        } catch (Exception e) {

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
            if(_validator.IsValid(visit))
            {
                if (await visit.save())
                {
                    return CreatedAtAction("Save", visit);
                }
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

    [HttpPut("addvisitors/{id}")]
    public async Task<IActionResult> addVisitors(string id, [FromBody] Visitor visitor)
    {
        try
        {
            VisitorValidator validator = new VisitorValidator();
            Visit visit = new Visit();
            visit = await visit.getOne(id);

            if (!validator.IsValid(visitor))
            {
                return BadRequest(validator.getErrors());
            }

            List<Visitor> newVisitors = new List<Visitor>();
            if (visit.visitors != null)
            {
                newVisitors = visit.visitors.ToList();
            }

            if (!ALLOW_SAME_NAME && Array.FindAll(visit.visitors, x => x.Name == visitor.Name).Length > 0)
            {
                return BadRequest("Você já marcou presença nessa visita");
            }

            Visitor savedVisitor = await visitor.getByName();

            if (savedVisitor != null)
            {
                visitor = savedVisitor;
            } else
            {
                await visitor.save();
            }

            newVisitors.Add(visitor);
            visit.visitors = newVisitors.ToArray();

            if (await visit.update())
            {
                return CreatedAtAction("Update", visitor);
            }

            return BadRequest();
        }
        catch
        {
            return StatusCode(500);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(string id)
    {
        try
        {
            Visit visit = new Visit();
            visit.Id = id;

            if (await visit.delete())
            {
                return Ok();
            }

            return BadRequest();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
