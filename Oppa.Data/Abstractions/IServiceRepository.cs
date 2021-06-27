using Oppa.Data.Enums;
using Oppa.Data.Models;
using System.Collections.Generic;

namespace Oppa.Data.Abstractions
{
    public interface IServiceRepository
    {
        List<Service> GetAll(ProductTypeEnum? productType);
        Service GetById(int id);
        void Delete(Service entity);
        void Create(Service entity);
        void Update(Service entity);
    }
}
