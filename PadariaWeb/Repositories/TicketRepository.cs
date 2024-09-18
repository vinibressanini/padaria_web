using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Repositories
{
    public class TicketRepository : IRepository<Ticket, int>
    {

        private readonly AppDbContext _dbContext;

        public TicketRepository(AppDbContext dbContext) =>_dbContext = dbContext;
        public async Task Delete(int id)
        {
            Ticket? ticket = await GetById(id);

            _dbContext.Ticket.Remove(ticket);

            await _dbContext.SaveChangesAsync();


        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _dbContext.Ticket
                .AsNoTracking()
                .Include(tic => tic.PaymentMethod)
                .Include(tic => tic.ProductTickets)
                .Include(tic => tic.Products)
                .ToListAsync();
        }


        public async Task<Ticket> GetById(int id)
        {
            Ticket? ticket = await _dbContext.Ticket
                .AsNoTracking()
                .Include(tic => tic.PaymentMethod)
                .Include(tic => tic.ProductTickets)
                .Include(tic => tic.Products)
                .FirstOrDefaultAsync(tic => tic.Id ==  id);

            if (ticket == null) throw new ArgumentException("Ticket Not Found");
            return ticket;
        }

        public async Task<Ticket> Save(Ticket entity)
        {
            try
            {
                await _dbContext.Ticket.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ticket Update(Ticket entity)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(entity.Id))
                {
                    throw new ArgumentException("Ticket Not Found.");
                }
                else
                {
                    throw;
                }
            }

            return entity;
        }

        private bool TicketExists(int id) => GetById(id) != null;
    }
}
