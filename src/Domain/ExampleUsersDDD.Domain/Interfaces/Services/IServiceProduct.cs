
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ExampleUsersDDD.Domain.Entities;

namespace  ExampleUsersDDD.Domain.Interfaces.Services
{
    public interface IServiceProduct
    {
        // Reading(Consultation):
        // Task<IList<Product>> getAllByStatus(bool status);

        // Writing(Persistence):
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
    }
}
