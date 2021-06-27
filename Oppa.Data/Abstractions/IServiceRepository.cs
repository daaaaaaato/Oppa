using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Data.Abstractions
{
    public interface IServiceRepository
    {
        List<Service> GetAll();
        Service GetById(int id);
        void Delete(Service entity);
        void Create(Service entity);
        void Update(Service entity);
    }
}
