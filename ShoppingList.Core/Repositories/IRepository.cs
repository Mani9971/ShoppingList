using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<int> Add(T entity);
        Task<int> Delete(int id);
        Task<int> Update(T entity);
    }
}
