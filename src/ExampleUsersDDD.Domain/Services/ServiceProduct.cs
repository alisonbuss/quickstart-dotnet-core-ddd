
using System.Threading.Tasks;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Services;
using ExampleUsersDDD.Domain.Interfaces.Repositories;

namespace ExampleUsersDDD.Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IUnitOfWorkRepository kraken;

        public ServiceProduct(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.kraken = unitOfWorkRepository;
        }

        // Reading(Consultation):
        // public async Task<IList<Product>> getAllByStatus(bool status)
        // {
        //     throw new NotImplementedException();
        // }


        // Writing(Persistence):
        public async Task<Product> AddProduct(Product product)
        {
            // var validateName = product.ValidatePropertyString(product.Name, "Name");

            // var validatePrice = product.ValidatePropertyDecimal(product.Price, "Price");

            // if (validateName && validatePrice)
            // {
            //     product.Status = true;

            //     await this.kraken.repositoryProduct.Add(product);
            // }

            return await this.kraken.RepositoryProduct.Add(product);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            // var validateName = product.ValidatePropertyString(product.Name, "Name");

            // var validatePrice = product.ValidatePropertyDecimal(product.Price, "Price");

            // if (validateName && validatePrice)
            // {
            //     await this.kraken.repositoryProduct.Update(product);
            // }

            return await this.kraken.RepositoryProduct.Update(product);
        }
        
    }
}
