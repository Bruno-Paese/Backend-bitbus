using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;
using POCMONGO.Controllers.Filter;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Controllers.Filter
{
    [ApiController]
    [Route("api/[controller]")]
    public class LectureController : ControllerBase
    {
        private const bool ALLOW_SAME_NAME = true;
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LectureFilter? filter)
        {
            try
            {
                var result = await (new Lecture()).getAll(filter);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            try
            {
                return Ok(await (new Lecture()).getOne(id));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> save([FromBody] Lecture lecture)
        {
            try
            {
                var saveResult = await lecture.save();
                if (saveResult)
                {
                    return CreatedAtAction("Save", lecture);
                }

                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> update([FromBody] Lecture lecture)
        {
            try
            {
                if (await lecture.update())
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(string id)
        {
            try
            {
                 Lecture lecture = new Lecture();
                lecture.Id = id;
                if (await lecture.delete())
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
}

