using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System.Collections.Generic;

namespace Oppa.Services.Abstractions
{
    public interface IProductsService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Delete(Product entity);
        void Create(CreateProductViewModel model);
        void Update(UpdateProductViewModel from, Product to);
    }
}
