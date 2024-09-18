using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Repositories
{
    public class CustomerRepostory : IRepository<LoyalCustomer, int>
    {

        private readonly AppDbContext _dbContext;
        public CustomerRepostory(AppDbContext dbContext) => _dbContext = dbContext;
        public async Task Delete(int id)
        {
            LoyalCustomer? customer = await GetById(id);

            if (customer != null)
            {
                _dbContext.Customer.Remove(customer);
                await _dbContext.SaveChangesAsync();
            } else
            {
                throw new ArgumentException("User not Found");
            }
        }

        public async Task<IEnumerable<LoyalCustomer>> GetAll()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task<LoyalCustomer> GetById(int id)
        {
            return await _dbContext.Customer
                .Include(c => c.Tickets)
                .ThenInclude(tic => tic.ProductTickets)
                .Include(c => c.Tickets)
                .ThenInclude(tic => tic.Products)
                .Include(c => c.Tickets)
                .ThenInclude(tic => tic.PaymentMethod)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<LoyalCustomer> Save(LoyalCustomer entity)
        {
            try
            {
                await _dbContext.Customer.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public LoyalCustomer Update(LoyalCustomer entity)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoyalCustomerExists(entity.Id))
                {
                    throw new ArgumentException("User Not Found");
                }
                else
                {
                    throw;
                }
            }

            return entity;
        }

        private bool LoyalCustomerExists(int id)
        {
            return GetById(id) != null;
        }

    }
}
