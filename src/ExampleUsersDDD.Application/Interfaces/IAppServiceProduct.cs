
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using ExampleUsersDDD.Application.Dtos;

namespace ExampleUsersDDD.Application.Interfaces
{
    public interface IAppServiceProduct : IDisposable
    {
        // Reading(Consultation):
        Task<IEnumerable<DtoProduct>> GetAll();
        //Task<IList<DtoProduct>> getAllByStatus(bool status);
        Task<DtoProduct> GetById(int id);
        
        // Writing(Persistence):
        Task<DtoProduct> Add(DtoProduct dtoProduct);
        Task<DtoProduct> Update(DtoProduct dtoProduct);
        Task Remove(DtoProduct dtoProduct);
        
    }
}
