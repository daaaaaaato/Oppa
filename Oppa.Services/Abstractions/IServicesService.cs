using Oppa.Data.Enums;
using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System.Collections.Generic;

namespace Oppa.Services.Abstractions
{
    public interface IServicesService
    {
        List<Service> GetAll(ProductTypeEnum? productType);
        Service GetById(int id);
        void Delete(Service entity);
        void Create(CreateServiceViewModel model);
        void Update(UpdateServiceViewModel from, Service to);
    }
}
