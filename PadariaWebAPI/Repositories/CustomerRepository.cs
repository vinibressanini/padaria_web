using Microsoft.EntityFrameworkCore;
using PadariaWebAPI.Data;
using PadariaWebAPI.DTO;
using PadariaWebAPI.Models;

namespace PadariaWebAPI.Repositories
{
    public class CustomerRepository
    {
        private readonly AppDbContext _dbContext;
        public CustomerRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task<LoyalCustomer> UpdateUserPoints(UserPointsPostRequestBody dto)
        {
            LoyalCustomer customer = await _dbContext.Customer.FirstOrDefaultAsync(c => c.Id == dto.UserId);

            if (customer == null)
            {
                throw new ArgumentException("User not Found");
            }

            double points = dto.PurchaseTotalPrice * 0.10;

            customer.Points += points;

            try
            {
                _dbContext.Attach(customer).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return customer;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}
