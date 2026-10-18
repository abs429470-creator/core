using core.Models;
namespace interfaces ;

public interface IdetailsOfBabyService
{
    List<DetailsOfBaby> GetAll();
    DetailsOfBaby Get(int id);
    void Add(DetailsOfBaby baby);
    void Update(int id, DetailsOfBaby baby);
    void Delete(int id);
}
