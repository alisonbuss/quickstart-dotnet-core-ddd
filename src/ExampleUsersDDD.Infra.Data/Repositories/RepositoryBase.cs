
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

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
        protected readonly DbContextBase _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(DbContextBase dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        // Reading(Consultation):

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        // Writing(Persistence):

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await _dbSet.AddAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = await GetById(entity.Id);
            if (currentEntity == null)
                throw new System.ArgumentNullException(nameof(currentEntity));

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(entity);

            _dbSet.Update(currentEntity);

            return await Task.FromResult<TEntity>(currentEntity);
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = await GetById(entity.Id);
            if (currentEntity == null)
                throw new System.ArgumentNullException(nameof(currentEntity));

            _dbSet.Remove(currentEntity);

            await Task.CompletedTask;
        }

    }
}
