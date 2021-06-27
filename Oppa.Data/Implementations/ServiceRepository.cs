﻿using Microsoft.EntityFrameworkCore;
using Oppa.Data.Abstractions;
using Oppa.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // log the error
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
                // log the error
                tx.Rollback();
            }
        }

        public List<Service> GetAll()
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
                .ToList();
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
                // log the error
                tx.Rollback();
            }
        }
    }
}
