
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
        private readonly IRepositoryProduct _repositoryProduct;
        private readonly IServiceProduct _serviceProduct;
        private readonly IMapper _mapper;

        public AppServiceProduct(IRepositoryProduct repositoryProduct, 
                                 IServiceProduct serviceProduct,
                                 IMapper mapper)
        {
            _repositoryProduct = repositoryProduct;
            _serviceProduct = serviceProduct;
            _mapper = mapper;
        }

        // Reading(Consultation):
        public async Task<IEnumerable<DtoProduct>> GetAll()
        {
            return _mapper.Map<IEnumerable<DtoProduct>>(
                await _repositoryProduct.GetAll()
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
                await _repositoryProduct.GetById(id)
            );
        }

        // Writing(Persistence):
        public async Task<DtoProduct> Add(DtoProduct dtoProduct)
        {
            var product = _mapper.Map<Product>(dtoProduct);

            return _mapper.Map<DtoProduct>(
                await _repositoryProduct.Add(product)
            );
        }

        public async Task<DtoProduct> Update(DtoProduct dtoProduct)
        {
            var product = _mapper.Map<Product>(dtoProduct);
            
            return _mapper.Map<DtoProduct>(
                await _repositoryProduct.Update(product)
            );
        }

        public async Task Remove(DtoProduct dtoProduct)
        {
            var product = _mapper.Map<Product>(dtoProduct);
            await _repositoryProduct.Remove(product);
        }

        // Writing(Persistence): Customized methods:
        public async Task<DtoProduct> AddProduct(DtoProduct dtoProduct)
        {
            var product = _mapper.Map<Product>(dtoProduct);       
            
            return _mapper.Map<DtoProduct>(
                await _serviceProduct.AddProduct(product)
            );
        }

        public async Task<DtoProduct> UpdateProduct(DtoProduct dtoProduct)
        {
            var product = _mapper.Map<Product>(dtoProduct);

            return _mapper.Map<DtoProduct>(
                await _serviceProduct.UpdateProduct(product)
            );
        }

        // From class:
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
    }
}
