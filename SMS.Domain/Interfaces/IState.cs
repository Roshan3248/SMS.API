using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
    public interface IState
    {
        List<State> GetAll();

        bool Add(State state);

        bool Delete(int Id);

        bool Update(State state);
    }
}
