using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BetterSpotify.DataAccess.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext Context;
        internal DbSet<T> DbSet { get; set; }

        public Repository(ApplicationDbContext dbContext)
        {
            Context = dbContext;
            this.DbSet = Context.Set<T>();
        }


        public T GetFirstOrDefault(Expression<Func<T, bool>> filterExpression)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(filterExpression);

            return query.First();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
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
