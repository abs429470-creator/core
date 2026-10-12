using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace core.Controllers;
[ApiController]
[Route("[controller]")]
public class DetailsOfBabiesController : ControllerBase
{
    private static List<DetailsOfBabies>? arrayOfBabies;

    public DetailsOfBabiesController() => arr = Enumerable.Range(1, 5).Select(index => new DetailsOfBabies
    {
        babyId=Random.Shared.Next(111111111,999999999),
        babiesWeight=Random.Shared.Next(2.5,5.5),
        timeOfBirth=new(new()),
        cribNumber=Random.Shared.Next(10,20),
    }).ToList();
    [HttpGet]
    public IEnumerable<DetailsOfBabies> Get()
    {
        return arrayOfBabies;
    }
    [HttpGet("{id}")]
     public ActionResult<DetailsOfBabies> Get(int id)
    {
        var res=arrayOfBabies?.FirstOrDifault(b=>b.babyId=id);
       if (res == null)
            return NotFound();
        return res;
    }
}
