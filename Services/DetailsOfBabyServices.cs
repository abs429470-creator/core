using core.Models;
using interfaces;

namespace Server;

public class DetailsOfBabyServices : IdetailsOfBabyService
{
    List<DetailsOfBaby> arrayOfBabies {get;}

    public DetailsOfBabyServices() => arrayOfBabies = Enumerable.Range(1, 5).Select(index => new DetailsOfBaby
    {
        babyId = Random.Shared.Next(111111111, 999999999),
        babiesWeight = 2.5 + Random.Shared.NextDouble() * 3,
        timeOfBirth = DateTime.Now,
        cribNumber = Random.Shared.Next(10, 20),
    }).ToList();

    public List<DetailsOfBaby> Get() => arrayOfBabies;
    public DetailsOfBaby? Get(int id)=> arrayOfBabies.FirstOrDefault(b => b.babyId == id);

    public void Add(DetailsOfBaby baby)
    {
        arrayOfBabies?.Add(baby);
    }

    public void Update(int id, DetailsOfBaby baby)
    {
        var res = arrayOfBabies?.FirstOrDefault(b => b.babyId == id);
        if (res == null)
            throw new Exception("Not Found");
        res.babyName = baby.babyName;
        res.cribNumber = baby.cribNumber;
        res.timeOfBirth = baby.timeOfBirth;
        res.babiesWeight = baby.babiesWeight;
    }

    public void Delete(int id)
    {
        var res = arrayOfBabies?.FirstOrDefault(b => b.babyId == id);
        if (res == null)
            return;
        arrayOfBabies?.Remove(res);
    }
}