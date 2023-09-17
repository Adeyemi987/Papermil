using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Infrastructure.Repository.Abstraction
{
    public interface ICommandIRepository<in T> where T : class
    {
        Task CreateAsync(T entity);
        void DeleteAsync(T entity);
        void Update(T entity);
        void RemoveRange(IEnumerable<T> entities);
        // IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        //IQueryable<T> FindAll(bool I);
    }
}
