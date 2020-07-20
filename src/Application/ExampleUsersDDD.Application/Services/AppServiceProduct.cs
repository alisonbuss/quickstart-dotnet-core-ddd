
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Domain.Interfaces.Services;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Services
{
    public class AppServiceProduct : IAppServiceProduct
    {
        private readonly IUnitOfWorkRepository _kraken;
        
        private readonly IMapper _mapper;

        public AppServiceProduct(IUnitOfWorkRepository unitOfWorkRepository,
                                 IMapper mapper)
        {
            _kraken = unitOfWorkRepository;
            _mapper = mapper;
        }

        // Reading(Consultation):
        public async Task<IEnumerable<DtoProduct>> GetAll()
        {
            return _mapper.Map<IEnumerable<DtoProduct>>(
                await _kraken.RepositoryProduct.GetAll()
            );
        }

        // public async Task<IList<DtoProduct>> getAllByStatus(bool status)
        // {
        //     return _mapper.Map<IList<DtoProduct>>(
        //         await _repositoryProduct.getAllByStatus(status)
        //     );
        // }

        public async Task<DtoProduct> GetById(int id)
        {
            return _mapper.Map<DtoProduct>(
                await _kraken.RepositoryProduct.GetById(id)
            );
        }

        // Writing(Persistence):
        public async Task<DtoProduct> Add(DtoProduct dtoProduct)
        {
            try
            {
                var currentProduct = _mapper.Map<Product>(dtoProduct);

                var newProduct = await _kraken.RepositoryProduct.Add(currentProduct);
                await _kraken.Commit();

                return _mapper.Map<DtoProduct>(newProduct);
            }
            catch (Exception exception)
            {
                await _kraken.Rollback(); throw exception;
            }
        }

        public async Task<DtoProduct> Update(DtoProduct dtoProduct)
        {
            try
            {
                var currentProduct = _mapper.Map<Product>(dtoProduct);
                
                var updatedProduct = await _kraken.RepositoryProduct.Update(currentProduct);
                await _kraken.Commit();

                return _mapper.Map<DtoProduct>(updatedProduct);
            }
            catch (Exception exception)
            {
                await _kraken.Rollback(); throw exception;
            }
        }

        public async Task Remove(DtoProduct dtoProduct)
        {
            try
            {
                var currentProduct = _mapper.Map<Product>(dtoProduct);
                
                await _kraken.RepositoryProduct.Remove(currentProduct);
                await _kraken.Commit();
            }
            catch (Exception exception)
            {
                await _kraken.Rollback(); throw exception;
            }
        }

        // From class:
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
    }
}
