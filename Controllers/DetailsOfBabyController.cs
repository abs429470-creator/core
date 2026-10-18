using core.Models;
using interfaces;
using Server;
using Microsoft.AspNetCore.Mvc;

namespace core.Controllers;

[ApiController]
[Route("[controller]")]
public class DetailsOfBabyController : ControllerBase
{
    private IdetailsOfBabyService detailsOfBabyService;
    public DetailsOfBabyController(IdetailsOfBabyService detailsOfBabyService)
    {
        this.detailsOfBabyService = detailsOfBabyService;
    }

    [HttpGet]
    public IEnumerable<DetailsOfBaby> Get()
    {
        return detailsOfBabyService.Get();
    }
    [HttpGet("{id}")]
    public ActionResult<DetailsOfBaby> Get(int id)
    {
        var res = detailsOfBabyService.Get(id);
        if (res == null)
            return NotFound();
        return res;
    }
    [HttpPost]
    public IActionResult Create(DetailsOfBaby baby)
    {
        detailsOfBabyService.Add(baby);
        return CreatedAtAction(nameof(Get), new { id = baby.babyId}, baby);
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, DetailsOfBaby baby)
    {
        if (id != baby.babyId)
            return BadRequest();
        var existingBaby = detailsOfBabyService.Get(id);
        if (existingBaby == null)
            return NotFound();
        detailsOfBabyService.Update(id, baby);
        return NoContent();
    }
      [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var baby = detailsOfBabyService.Get(id);
            if (baby is null)
                return  NotFound();

            detailsOfBabyService.Delete(id);

            return Content($"Baby with id {id} deleted successfully");
        }
}
