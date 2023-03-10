using System.Linq.Expressions;

namespace BetterSpotify.DataAccess.Repository._IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filterExpression, string? include = null);

        IEnumerable<T> GetAll(string? include = null);

        void Add(T item);

        void Remove(T item);

        void RemoveRange(IEnumerable<T> items);
    }


}
