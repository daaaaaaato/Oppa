using Oppa.Data.Abstractions;
using Oppa.Data.Enums;
using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using Oppa.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Services.Implementations
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServicesService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public void Create(CreateServiceViewModel model)
        {
            var entity = new Service()
            {
                ProductId = model.ProductId,
                Name = model.Name
            };

            _serviceRepository.Create(entity);
        }

        public void Delete(Service entity)
        {
            _serviceRepository.Delete(entity);

        }

        public List<Service> GetAll(ProductTypeEnum? productType)
        {
            return _serviceRepository.GetAll(productType);

        }

        public Service GetById(int id)
        {
            return _serviceRepository.GetById(id);
        }

        public void Update(UpdateServiceViewModel from, Service to)
        {
            to.Name = from.Name;
            to.ProductId = from.ProductId;

            _serviceRepository.Update(to);
        }
    }
}
