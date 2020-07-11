
using System;
using System.Collections.Generic;
using System.Text;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Repositories;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        // Reading(Consultation):
        // public async Task<IList<DtoProduct>> getAllByStatus(bool status) OR
        // public async Task<TEntity> GetByEmail(string email)
        // {
        //     return await _dbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        //     return await _dbSet.AsNoTracking().Where(x => x.Status == true).ToListAsync();
        // }

    }
}
