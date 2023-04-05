using Microsoft.EntityFrameworkCore;
using NewsModule.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity> Query();

    }
}
