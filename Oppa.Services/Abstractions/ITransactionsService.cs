using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using System.Collections.Generic;

namespace Oppa.Services.Abstractions
{
    public interface ITransactionsService
    {
        ServiceResponse Create(CreateTransactionViewModel model);
        List<Transaction> GetAll();
        Transaction GetById(long id);
    }
}
