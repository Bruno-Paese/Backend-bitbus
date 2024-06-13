using Microsoft.AspNetCore.Mvc;
using POCMONGO.Controllers.DTO;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpinionController : ControllerBase
    {
        [HttpGet("{visitId}")]
        public async Task<List<OpinionDTO>> Get(string visitId)
        {
            Opinion opinion = new Opinion();
            opinion.visit = new Visit();
            opinion.visit.Id = visitId;

            List<Opinion> opinions = await opinion.getAll();
            List<OpinionDTO> DTOs = new List<OpinionDTO>();

            foreach (Opinion op in opinions)
            {
                OpinionDTO dto = new OpinionDTO();
                await dto.parseFromOpinion(op);
                DTOs.Add(dto);
            }

            return DTOs;

        }

        [HttpPost]
        public async Task<IActionResult> save([FromBody]OpinionDTO opinion)
        {
            Opinion parsedOpinion = await opinion.obtainData();

            if (await parsedOpinion.save())
            {
                return CreatedAtAction("Save", opinion);
            }

            return BadRequest();
        }
    }
}
