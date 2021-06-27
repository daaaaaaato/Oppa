using Microsoft.EntityFrameworkCore;
using Oppa.Data.Abstractions;
using Oppa.Data.Enums;
using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oppa.Data.Implementations
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Service entity)
        {
            var tx = _context.Database.BeginTransaction();
            try
            {
                entity.CreatedAtUtc = DateTime.UtcNow;

                _context.Services.Add(entity);
                _context.SaveChanges();
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }
        }

        public void Delete(Service entity)
        {
            var tx = _context.Database.BeginTransaction();
            try
            {
                _context.Services.Remove(entity);
                _context.SaveChanges();
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }
        }

        public List<Service> GetAll(ProductTypeEnum? productType)
        {
            var data = _context.Services
                .Include(c => c.Product)
                .AsQueryable();

            if (productType.HasValue)
                data = data.Where(c => c.Product.ProductType == productType.Value);

            return data.Select(g => new Service()
            {
                Name = g.Name,
                CreatedAtUtc = g.CreatedAtUtc,
                Id = g.Id,
                ModifiedAtUtc = g.ModifiedAtUtc,
                ProductId = g.ProductId
            }).ToList();

        }

        public Service GetById(int id)
        {
            return _context.Services
                .Include(c => c.Product)
                .Select(g => new Service()
                {
                    Name = g.Name,
                    CreatedAtUtc = g.CreatedAtUtc,
                    Id = g.Id,
                    ModifiedAtUtc = g.ModifiedAtUtc,
                    ProductId = g.ProductId
                })
                .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Service entity)
        {
            var tx = _context.Database.BeginTransaction();
            try
            {
                entity.ModifiedAtUtc = DateTime.UtcNow;
                _context.Services.Update(entity);
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
