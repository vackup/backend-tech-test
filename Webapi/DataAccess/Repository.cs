using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly DbContext context;
        protected readonly DbSet<TEntity> Entities;

        protected Repository(DbContext context)
        {
            this.context = context;
            this.Entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await this.Entities.SingleOrDefaultAsync(s => s.Id.Equals(id));
        }

        public async Task<TEntity> GetFirstOrDefaultAsync()
        {
            return await this.Entities.FirstOrDefaultAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                await this.Entities.AddAsync(entity);
                await this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                context.Entry(entity).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.Entities.Remove(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
