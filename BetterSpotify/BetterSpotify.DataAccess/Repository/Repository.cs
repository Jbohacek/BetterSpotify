using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BetterSpotify.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext Context;
        internal DbSet<T> DbSet { get; set; }

        public Repository(ApplicationDbContext dbContext)
        {
            Context = dbContext;

            this.DbSet = Context.Set<T>();
        }


        public T GetFirstOrDefault(Expression<Func<T, bool>> filterExpression, string? include = null)
        {
            IQueryable<T> query = DbSet;
            if (include != null)
            {
                foreach (var inc in include.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inc);
                }
            }

            query = query.Where(filterExpression);

            return query.First();
        }

        public IEnumerable<T> GetAll(string? include = null)
        {
            IQueryable<T> query = DbSet;
            if (include != null)
            {
                foreach (var inc in include.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inc);
                }
            }

            return query.ToList();
        }

        public void Add(T item)
        {
            Context.Add(item);
        }

        public void Remove(T item)
        {
            Context.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            Context.RemoveRange(items);
        }
    }
}
