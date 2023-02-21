using System.Linq.Expressions;

namespace BetterSpotify.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAll();

        void Add(T item);

        void Remove(T item);

        void RemoveRange(IEnumerable<T> items);
    }


}
