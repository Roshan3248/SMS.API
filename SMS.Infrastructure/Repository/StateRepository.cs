using SMS.Domain.Entities;
using SMS.Domain.Interfaces;


namespace SMS.Infrastructure.Repository
{
    public class StateRepository : IState
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<State> GetAll()
        {
            return _context.States.ToList();
        }

        public bool Add(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var States = _context.States.Find(Id);
            _context.States.Remove(States);
            _context.SaveChanges();
            return true;
        }


        public bool Update(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
            return true;
        }


    }
}
