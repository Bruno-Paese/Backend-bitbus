using Microsoft.AspNetCore.Mvc;
using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationController: ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> save(Donation donation)
        {
            try
            {
                DonationValidator dv = new DonationValidator();
                if (dv.IsValid(donation))
                {
                    await donation.save();
                    return CreatedAtAction("Save", donation);
                }
                return BadRequest();
            } catch (Exception ex) {
                return BadRequest();
            }
        }
    }
}
