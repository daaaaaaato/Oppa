using Oppa.Data.Models;
using System.Collections.Generic;

namespace Oppa.Data.Abstractions
{
    public interface ITransactionRepository
    {
        void Create(Transaction model);
        List<Transaction> GetAll();
        Transaction GetById(long id);
    }
}
