using core.models;
using Microsoft.AspNetCore.Mvc;

namespace core.Controllers;
[ApiController]
[Route("[controller]")]
public class DetailsOfBabyController : ControllerBase
{
    private static List<DetailsOfBaby>? arrayOfBabies;

    public DetailsOfBabyController() => arrayOfBabies = Enumerable.Range(1, 5).Select(index => new DetailsOfBaby
    {
        babyId=Random.Shared.Next(111111111,999999999),
        babiesWeight=2.5+Random.Shared.NextDouble()*3,
        timeOfBirth=DateTime.Now,
        cribNumber=Random.Shared.Next(10,20),
    }).ToList();

    // private static readonly List<DetailsOfBaby> arrayOfBabies =
    //     Enumerable.Range(1, 5).Select(index => new DetailsOfBaby
    //     {
    //         babyId = Random.Shared.Next(111111111, 999999999),
    //         babiesWeight = 2.5 + Random.Shared.NextDouble() * 3,
    //         timeOfBirth = DateTime.Now,
    //         cribNumber = Random.Shared.Next(10, 20),
    //     }).ToList();

    [HttpGet]
    public IEnumerable<DetailsOfBaby> Get()
    {
        return arrayOfBabies;
    }
    [HttpGet("{id}")]
     public ActionResult<DetailsOfBaby> Get(int id)
    {
        var res=arrayOfBabies?.FirstOrDefault(b=>b.babyId==id);
       if (res == null)
            return NotFound();
        return res;
    }
}
