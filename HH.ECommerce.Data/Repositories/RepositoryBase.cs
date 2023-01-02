using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using HH.ECommerce.Data.Contracts;

namespace HH.ECommerce.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void Create(T entity) => _context
            .Set<T>()
            .Add(entity);

        public IQueryable<T> FindAll(bool trackChanges) => trackChanges 
            ? _context.Set<T>()
            : _context
                .Set<T>()
                .AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => trackChanges
            ? _context
                .Set<T>()
                .Where(expression)
            : _context
                .Set<T>()
                .Where(expression)
                .AsNoTracking();

        public void Update(T entity) => _context
            .Set<T>()
            .Update(entity);
    }
}
