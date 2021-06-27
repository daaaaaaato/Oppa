using Oppa.Data.Enums;
using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Data.Abstractions
{
    public interface IProductRepository
    {
        Product GetByProductType(ProductTypeEnum productType);
        List<Product> GetAll();
        Product GetById(int id);
        void Delete(Product entity);
        void Create(Product entity);
        void Update(Product entity);
    }
}
