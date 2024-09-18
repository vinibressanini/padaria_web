using PadariaWeb.Models;

namespace PadariaWeb.Repositories
{
    public class PaymentRepository : IRepository<PaymentMethod, int>
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PaymentMethod>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethod> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethod> Save(PaymentMethod entity)
        {
            throw new NotImplementedException();
        }

        public PaymentMethod Update(PaymentMethod entity)
        {
            throw new NotImplementedException();
        }
    }
}
