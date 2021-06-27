using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Services.Abstractions
{
    public interface IServicesService
    {
        List<Service> GetAll();
        Service GetById(int id);
        void Delete(Service entity);
        void Create(CreateServiceViewModel model);
        void Update(UpdateServiceViewModel from, Service to);
    }
}
