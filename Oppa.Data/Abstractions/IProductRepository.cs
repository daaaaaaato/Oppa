using Oppa.Data.Enums;
using Oppa.Data.Models;
using System.Collections.Generic;

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
