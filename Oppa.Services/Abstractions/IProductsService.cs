using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
