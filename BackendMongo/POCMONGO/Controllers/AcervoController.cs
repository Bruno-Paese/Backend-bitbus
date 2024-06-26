﻿using Microsoft.AspNetCore.Mvc;
using POCMONGO.Controllers.Filter;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcervoController : ControllerBase
    {
        private const bool ALLOW_SAME_NAME = true;
        private readonly AcervoValidator _validator = new AcervoValidator();

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AcervoFilter? filter)
        {
            try
            {
                var result = await (new Acervo()).getAll(filter);
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
                return Ok(await (new Acervo()).getOne(id));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult > create([FromBody] Acervo acervo)
        {
            try
            {
                if (_validator.IsValid(acervo))
                {
                    if (await acervo.create())
                    {
                        return CreatedAtAction("Create", acervo);
                    }
                }
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPut]
        public async Task<IActionResult> update([FromBody] Acervo acervo)
        {
            try
            {
                if (await acervo.update())
                {
                    return CreatedAtAction("Update", acervo);
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
                Acervo acervo =  new Acervo();
                acervo.Id = id;
                if (!await acervo.delete())
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
