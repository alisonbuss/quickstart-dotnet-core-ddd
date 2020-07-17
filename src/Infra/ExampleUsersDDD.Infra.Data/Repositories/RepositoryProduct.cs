
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        public RepositoryProduct(DbContextBase dbContext) : base(dbContext)
        {
            
        }
        
        public override async Task<Product> GetById(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public override async Task<Product> Update(Product entity) 
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();

            return await Task.FromResult<Product>(entity);
        }

        public override async Task Remove(Product entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();

            await Task.CompletedTask;
        }
       
    }
}
