using core.models;
namespace interfaces ;

public interface IdetailsOfBabyServer
{
    List<DetailsOfBaby> GetAll();
    DetailsOfBaby Get(int id);
    void Add(DetailsOfBaby baby);
    void Update(int id, DetailsOfBaby baby);
    void Delete(int id);
}
