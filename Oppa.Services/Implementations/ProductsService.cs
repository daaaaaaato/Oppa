using Oppa.Data.Abstractions;
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
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(CreateProductViewModel model)
        {
            // here should be custom model validations

            var entity = new Product()
            {
                CommisionPercentage = model.CommisionPercentage,
                CommissionMinAmount = model.CommissionMinAmount,
                Name = model.Name,
                ProductType = model.ProductType,
                TransactionMaxAmount = model.TransactionMaxAmount,
                TransactionMinAmount = model.TransactionMinAmount
            };

            _productRepository.Create(entity);

        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(UpdateProductViewModel from, Product to)
        {
            to.Name = from.Name;
            to.CommissionMinAmount = from.CommissionMinAmount;
            to.CommisionPercentage = from.CommisionPercentage;
            to.TransactionMinAmount = from.TransactionMinAmount;
            to.TransactionMaxAmount = from.TransactionMaxAmount;
            to.ProductType = from.ProductType;

            _productRepository.Update(to);
        }
    }
}
