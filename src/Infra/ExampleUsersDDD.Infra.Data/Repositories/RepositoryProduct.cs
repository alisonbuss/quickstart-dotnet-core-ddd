
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
        

       
    }
}
