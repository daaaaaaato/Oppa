using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Data.Abstractions
{
    public interface ITransactionRepository
    {
        void Create(Transaction model);
        List<Transaction> GetAll();
        Transaction GetById(long id);
    }
}
