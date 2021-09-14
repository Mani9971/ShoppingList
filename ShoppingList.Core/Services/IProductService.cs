using ShoppingList.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Services
{
    public interface IProductService
    {
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<bool> Add(Product entity);
        Task<bool> Delete(int id);
        Task<bool> Update(Product entity);
    }
}
