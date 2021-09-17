using Microsoft.EntityFrameworkCore;
using ShoppingList.Core.Models;
using ShoppingList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Dal
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingListDatabaseContext _context;

        public ShoppingCartRepository(ShoppingListDatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Add(ShoppingCart entity)
        {
            await _context.ShoppingCart.AddAsync(entity);
            var save = await _context.SaveChangesAsync();
            return save;
        }

        public async Task<int> Delete(int id)
        {
            var foundObject = await _context.ShoppingCart.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (foundObject != null)
            {
                _context.ShoppingCart.Remove(foundObject);
                var save = await _context.SaveChangesAsync();
                return save;
            }
            return 0;
        }

        public async Task<ShoppingCart> Get(int id)
        {
            return await _context.ShoppingCart.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAll()
        {
            return await _context.ShoppingCart.ToListAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartWithProducts(int id)
        {
            var shoppingCart = await _context.ShoppingCart.Where(x => x.Id == id).Include(x => x.Products).FirstOrDefaultAsync();
            if (shoppingCart != null)
            {
                return shoppingCart;
            }
            return null;

        }

        public async Task<int> Update(ShoppingCart entity)
        {
            var foundObject = await _context.ShoppingCart.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (foundObject != null)
            {
                _context.Entry(foundObject).CurrentValues.SetValues(entity);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> AddProductToShoppingCart(Product product, int id)
        {
            var shoppingCartTask = _context.ShoppingCart.Where(x => x.Id == id).Include(x => x.Products).FirstOrDefaultAsync();
            var foundShoppingCart = shoppingCartTask.Result;
            var foundShoppingCartProduct = await _context.Products.Where(x => x.Name == product.Name && x.Price == product.Price).FirstOrDefaultAsync();
            if (foundShoppingCartProduct == null)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                foundShoppingCartProduct = await _context.Products.Where(x => x.Name == product.Name && x.Price == product.Price).FirstOrDefaultAsync();
            }

            if (foundShoppingCartProduct != null)
            {
                if (foundShoppingCart.Products.Where(x => x.Id == foundShoppingCartProduct.Id).FirstOrDefault() == null)
                {
                    foundShoppingCart.Products.Add(foundShoppingCartProduct);
                }
            }
            _context.SaveChanges();

            return foundShoppingCart;
        }

        public async Task<int> RemoveProductFromShoppingCart(int listId, int productID)
        {
            var shoppingCartTask = _context.ShoppingCart.Where(x => x.Id == listId).Include(x => x.Products).FirstOrDefaultAsync();
            var foundShoppingCart = shoppingCartTask.Result;
            var foundShoppingCartProduct = foundShoppingCart.Products.Where(x => x.Id == productID).FirstOrDefault();
            if (foundShoppingCartProduct != null)
            {
                var removed = foundShoppingCart.Products.Remove(foundShoppingCartProduct);
                if (removed == true)
                {
                    _context.ShoppingCart.Update(foundShoppingCart);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CheckUncheckItem(int listId, int productId)
        {
            var shoppingCartTask = _context.ShoppingCart.Where(x => x.Id == listId).Include(x => x.Products).FirstOrDefaultAsync();
            var foundShoppingCart = shoppingCartTask.Result;
            var foundShoppingCartProduct = foundShoppingCart.Products.Where(x => x.Id == productId).FirstOrDefault();
            if (foundShoppingCartProduct != null)
            {
                foundShoppingCartProduct.IsChecked = !foundShoppingCartProduct.IsChecked;

                _context.ShoppingCart.Update(foundShoppingCart);

            }
            return await _context.SaveChangesAsync();
        }
    }
}
