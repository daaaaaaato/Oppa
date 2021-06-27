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
    }
}
