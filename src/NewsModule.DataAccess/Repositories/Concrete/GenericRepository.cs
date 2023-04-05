using Microsoft.EntityFrameworkCore;
using NewsModule.DataAccess.DataContexts;
using NewsModule.DataAccess.Repositories.Interfaces;
using NewsModule.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NewsModule.DataAccess.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public NewsDataContext Context { get; set; }
        public DbSet<TEntity> Table { get; set; }

        public GenericRepository(NewsDataContext context)
        {
            Context = context;
            Table = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<TEntity> Query()
        {
            return Table.AsQueryable();
        }
    }
}
