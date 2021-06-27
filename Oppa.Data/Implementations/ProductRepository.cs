using Microsoft.EntityFrameworkCore;
using Oppa.Data.Abstractions;
using Oppa.Data.Enums;
using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oppa.Data.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            var tx = _context.Database.BeginTransaction();
            try
            {
                entity.CreatedAtUtc = DateTime.UtcNow;

                _context.Products.Add(entity);
                _context.SaveChanges();
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }
        }

        public void Delete(Product entity)
        {
            var tx = _context.Database.BeginTransaction();
            try
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products
                .Include(c => c.Services)
                .Select(g => new Product()
                {
                    Id = g.Id,
                    CommisionPercentage = g.CommisionPercentage,
                    CommissionMinAmount = g.CommissionMinAmount,
                    CreatedAtUtc = g.CreatedAtUtc,
                    ModifiedAtUtc = g.ModifiedAtUtc,
                    Name = g.Name,
                    ProductType = g.ProductType,
                    Services = g.Services,
                    TransactionMaxAmount = g.TransactionMaxAmount,
                    TransactionMinAmount = g.TransactionMinAmount
                })
                .ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products
                .Include(c => c.Services)
                .Select(g => new Product()
                {
                    Id = g.Id,
                    CommisionPercentage = g.CommisionPercentage,
                    CommissionMinAmount = g.CommissionMinAmount,
                    CreatedAtUtc = g.CreatedAtUtc,
                    ModifiedAtUtc = g.ModifiedAtUtc,
                    Name = g.Name,
                    ProductType = g.ProductType,
                    Services = g.Services,
                    TransactionMaxAmount = g.TransactionMaxAmount,
                    TransactionMinAmount = g.TransactionMinAmount
                })
                .FirstOrDefault(c => c.Id == id);
        }

        public Product GetByProductType(ProductTypeEnum productType)
        {
            return _context.Products.FirstOrDefault(c => c.ProductType == productType);
        }

        public void Update(Product entity)
        {
            var tx = _context.Database.BeginTransaction();
            try
            {
                entity.ModifiedAtUtc = DateTime.UtcNow;
                _context.Products.Update(entity);
                _context.SaveChanges();
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }

        }
    }
}
