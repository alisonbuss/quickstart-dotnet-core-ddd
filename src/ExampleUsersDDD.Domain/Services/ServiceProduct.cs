﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Domain.Interfaces.Services;

namespace ExampleUsersDDD.Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IUnitOfWorkRepository _kraken;

        public ServiceProduct(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _kraken = unitOfWorkRepository;
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

            //     await _repositoryProduct.Add(product);
            // }

            return await _kraken.RepositoryProduct.Add(product);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            // var validateName = product.ValidatePropertyString(product.Name, "Name");

            // var validatePrice = product.ValidatePropertyDecimal(product.Price, "Price");

            // if (validateName && validatePrice)
            // {
            //     await _repositoryProduct.Update(product);
            // }

            return await _kraken.RepositoryProduct.Update(product);
        }
        
    }
}