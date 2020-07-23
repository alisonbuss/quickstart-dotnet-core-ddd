
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Repositories;

using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    // https://thecodebuzz.com/efcore-dbcontext-cannot-access-disposed-object-net-core/
    // https://medium.com/@chathuranga94/unit-of-work-for-asp-net-core-706e71abc9d1
    // https://medium.com/swlh/creating-a-worker-service-in-asp-net-core-3-0-6af5dc780c80

    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContextBase dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryBase(DbContextBase dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        // Reading(Consultation):

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await this.dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        // Writing(Persistence):

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await this.dbSet.AddAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = await GetById(entity.Id);
            if (currentEntity == null)
                throw new System.ArgumentNullException(nameof(currentEntity));

            this.dbContext.Entry(currentEntity).CurrentValues.SetValues(entity);

            this.dbSet.Update(currentEntity);

            return await Task.FromResult<TEntity>(currentEntity);
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = await GetById(entity.Id);
            if (currentEntity == null)
                throw new System.ArgumentNullException(nameof(currentEntity));

            this.dbSet.Remove(currentEntity);

            await Task.CompletedTask;
        }

    }
}
