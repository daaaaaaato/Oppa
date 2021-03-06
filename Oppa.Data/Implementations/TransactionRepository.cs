using Oppa.Data.Abstractions;
using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oppa.Data.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Transaction model)
        {
            var response = new ServiceResponse();

            var tx = _context.Database.BeginTransaction();
            try
            {
                model.CreatedAtUtc = DateTime.UtcNow;

                _context.Transactions.Add(model);
                _context.SaveChanges();
                tx.Commit();
            }
            catch (Exception e)
            {
                tx.Rollback();
            }
        }

        public List<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetById(long id)
        {
            return _context.Transactions.Find(id);
        }
    }
}
