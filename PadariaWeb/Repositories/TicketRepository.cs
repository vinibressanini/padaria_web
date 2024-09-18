using PadariaWeb.Models;

namespace PadariaWeb.Repositories
{
    public class TicketRepository : IRepository<Ticket, int>
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> Save(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
