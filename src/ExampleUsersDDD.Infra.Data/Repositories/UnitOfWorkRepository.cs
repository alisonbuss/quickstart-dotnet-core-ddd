
using System;
using System.Threading.Tasks;

using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository, IDisposable
    {
        private readonly DbContextBase dbContext;
        private bool disposed;

        public UnitOfWorkRepository(DbContextBase dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Commit()
        {
            int affectedRows = await this.dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        public async Task Rollback()
        {
            await this.dbContext.DisposeAsync()
                .ConfigureAwait(false);
        }

        #region Discard Unit Of Work and DbContext.
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.dbContext.Dispose();
            this.disposed = true;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        // ...

        private IRepositoryProduct repositoryProduct;
        public  IRepositoryProduct RepositoryProduct
        {
            get { return this.repositoryProduct = this.repositoryProduct ?? new RepositoryProduct(this.dbContext); }
        }


    }
}
