using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Repositories
{
    public class PaymentRepository : IRepository<PaymentMethod, int>
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
            return;
        }
        
        public async Task Delete(int id)
        {
            var paymentmethod = await _context.PaymenyMethod.FindAsync(id);
            if (paymentmethod != null)
            {
                _context.PaymenyMethod.Remove(paymentmethod);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Payment method not found.");
            }
        }

        public async Task<IEnumerable<PaymentMethod>> GetAll()
        {
            return await _context.PaymenyMethod.ToListAsync();
        }

        public async Task<PaymentMethod> GetById(int id)
        {
            var paymentmethod = await _context.PaymenyMethod.FindAsync(id);
            if (paymentmethod == null)
            {
                throw new Exception("Payment method not found.");
            }
            return paymentmethod;
        }

        public async Task<PaymentMethod> Save(PaymentMethod entity)
        {
            await _context.PaymenyMethod.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<PaymentMethod> Update(PaymentMethod entity)
        {
            var existingPaymentMethod = await _context.PaymenyMethod.FindAsync(entity.Id);
            if (existingPaymentMethod == null)
            {
                throw new Exception("Payment method not found.");
            }

            _context.Entry(existingPaymentMethod).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingPaymentMethod;
        }
    }
}
