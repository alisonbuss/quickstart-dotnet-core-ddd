
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
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryBase()
        {
            this._optionsBuilder = new DbContextOptions<ContextBase>();
        }

        // From class:

        public async Task SaveAsync(ContextBase context)
        {
            await context.SaveChangesAsync();
        }


        // Reading(Consultation):

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            using (var data = new ContextBase(this._optionsBuilder))
            {
                return await data.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var data = new ContextBase(this._optionsBuilder))
            {
                return await data.Set<TEntity>().FindAsync(id);
                //return await data.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
            }
        }


        // Writing(Persistence):

        public async Task<TEntity> Add(TEntity obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<TEntity>().AddAsync(obj);
                await data.SaveChangesAsync();
                return obj;
            }
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<TEntity>().Update(obj);
                await data.SaveChangesAsync();
                return obj;
            }
        }
        
        public async Task Remove(TEntity obj)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                data.Set<TEntity>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }


        // From Doc Microsoft
        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }
            disposed = true;
        }
        #endregion

    }
}
