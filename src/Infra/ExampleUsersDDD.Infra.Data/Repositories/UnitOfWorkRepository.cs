
using System;
using System.Threading.Tasks;
using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository, IDisposable
    {
        private readonly DbContextBase _dbContext;
        private bool _disposed;

        public UnitOfWorkRepository(DbContextBase dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<int> Commit()
        {
            int affectedRows = await this._dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        public async Task Rollback()
        {
            await this._dbContext.DisposeAsync()
                .ConfigureAwait(false);
        }

        #region Discard Unit Of Work and DbContext.
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
                if (disposing)
                    this._dbContext.Dispose();
            this._disposed = true;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        // ...

        private IRepositoryProduct _repositoryProduct;
        public IRepositoryProduct RepositoryProduct
        {
            get { return _repositoryProduct = _repositoryProduct ?? new RepositoryProduct(_dbContext); }
        }


    }
}