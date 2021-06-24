using Oppa.Data.Abstractions;
using Oppa.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppa.Services.Implementations
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionsService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
    }
}
