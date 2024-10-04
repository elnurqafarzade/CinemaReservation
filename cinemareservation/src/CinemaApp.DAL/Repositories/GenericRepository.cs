using CinemaApp.Core.Entities.Base;
using CinemaApp.Core.Repositories;
using CinemaApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDBContext context;

        public GenericRepository(AppDBContext context)
        {
            this.context = context;
        }
        public DbSet<TEntity> Table => context.Set<TEntity>();

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public IQueryable<TEntity> GetByExpression(bool asNoTracking = false, System.Linq.Expressions.Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            query = asNoTracking == true
                ? query.AsNoTracking()
                : query;

            return expression is not null
                ? query.Where(expression)
                : query;

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }
    }
}

