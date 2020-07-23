
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Repositories;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Services
{
    public class AppServiceProduct : IAppServiceProduct
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWorkRepository kraken;

        public AppServiceProduct(
            IMapper mapper, IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.mapper = mapper;
            this.kraken = unitOfWorkRepository;
        }

        // Reading(Consultation):
        public async Task<IEnumerable<DtoProduct>> GetAll()
        {
            return this.mapper.Map<IEnumerable<DtoProduct>>(
                await this.kraken.RepositoryProduct.GetAll()
            );
        }

        // public async Task<IList<DtoProduct>> getAllByStatus(bool status)
        // {
        //     return this.mapper.Map<IList<DtoProduct>>(
        //         await this.kraken.repositoryProduct.getAllByStatus(status)
        //     );
        // }

        public async Task<DtoProduct> GetById(int id)
        {
            return this.mapper.Map<DtoProduct>(
                await this.kraken.RepositoryProduct.GetById(id)
            );
        }

        // Writing(Persistence):
        public async Task<DtoProduct> Add(DtoProduct dtoProduct)
        {
            try
            {
                var currentProduct = this.mapper.Map<Product>(dtoProduct);

                var newProduct = await this.kraken.RepositoryProduct.Add(currentProduct);
                await this.kraken.Commit();

                return this.mapper.Map<DtoProduct>(newProduct);
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        public async Task<DtoProduct> Update(DtoProduct dtoProduct)
        {
            try
            {
                var currentProduct = this.mapper.Map<Product>(dtoProduct);
                
                var updatedProduct = await this.kraken.RepositoryProduct.Update(currentProduct);
                await this.kraken.Commit();

                return this.mapper.Map<DtoProduct>(updatedProduct);
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        public async Task Remove(DtoProduct dtoProduct)
        {
            try
            {
                var currentProduct = this.mapper.Map<Product>(dtoProduct);
                
                await this.kraken.RepositoryProduct.Remove(currentProduct);
                await this.kraken.Commit();
            }
            catch (Exception exception)
            {
                await this.kraken.Rollback(); throw exception;
            }
        }

        // From class:
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
    }
}
