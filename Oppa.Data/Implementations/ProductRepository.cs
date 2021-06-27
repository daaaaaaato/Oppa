using Oppa.Data.Abstractions;
using Oppa.Data.Enums;
using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Data.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product GetByProductType(ProductTypeEnum productType)
        {
            return _context.Products.FirstOrDefault(c => c.ProductType == productType);
        }
    }
}
