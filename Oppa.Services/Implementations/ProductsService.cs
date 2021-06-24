using Oppa.Data.Abstractions;
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
    }
}
