using Microsoft.EntityFrameworkCore;
using PadariaWeb.Data;
using PadariaWeb.Models;

namespace PadariaWeb.Repositories
{
    public class ProductRepository : IRepository<Product, int>
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
            return;
        }
        public async Task Delete(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Product method not found.");
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product method not found.");
            }
            return product;
        }

        public async Task<Product> Save(Product entity)
        {
            await _context.Product.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Update(Product entity)
        {
            var existingProduct = await _context.Product.FindAsync(entity.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product method not found.");
            }

            _context.Entry(existingProduct).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
