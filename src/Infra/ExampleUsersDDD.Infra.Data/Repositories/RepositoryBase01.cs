
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;

using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    public class RepositoryBase01<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected readonly ContextBase _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase01(ContextBase context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        // From class:

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


        // Reading(Consultation):

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
            //return await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }


        // Writing(Persistence):

        public async Task<TEntity> Add(TEntity obj)
        {
           await _dbSet.AddAsync(obj);
           await this.SaveAsync();
           return obj;
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            _dbSet.Update(obj);
            await this.SaveAsync();
            return obj;
        }

        public async Task Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
            await this.SaveAsync();
        }


        // From Doc Microsoft
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
