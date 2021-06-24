using Oppa.Data.Abstractions;
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
    }
}
