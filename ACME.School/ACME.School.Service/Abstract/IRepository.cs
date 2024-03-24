using System.Linq.Expressions;

namespace ACME.School.Service.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        int Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
