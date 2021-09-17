using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Models;
using ShoppingList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Dal
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingListDatabaseContext _context;

        public ProductRepository(ShoppingListDatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Product entity)
        {
            await _context.Products.AddAsync(entity);
            var save = await _context.SaveChangesAsync();
            return save;
        }

        public async Task<int> Delete(int id)
        {
            var foundObject = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (foundObject != null)
            {
                _context.Products.Remove(foundObject);
                var save = await _context.SaveChangesAsync();
                return save;
            }
            return 0;
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<int> Update(Product entity)
        {
            var foundObject = await _context.Products.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (foundObject != null)
            {
                _context.Entry(foundObject).CurrentValues.SetValues(entity);
            }
            return await _context.SaveChangesAsync();
        }
    }
}

