using Oppa.Data.Abstractions;
using Oppa.Data.Enums;
using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using Oppa.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Oppa.Services.Helpers;

namespace Oppa.Services.Implementations
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IServiceRepository _serviceRepository;

        public TransactionsService(ITransactionRepository transactionRepository, IProductRepository productRepository, IServiceRepository serviceRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _serviceRepository = serviceRepository;
        }

        public ServiceResponse Create(CreateTransactionViewModel model)
        {
            var response = new ServiceResponse();

            var product = _productRepository.GetByProductType(model.ProductType);

            if (model.ProductType == ProductTypeEnum.MobilePhone)
            {
                model.PhoneNumber.ValidatePhone(ref response);

                model.TransactionAmount.ValidateTransactionAmount(ref product, ref response);
            }

            else if (product.ProductType == ProductTypeEnum.Charity || product.ProductType == ProductTypeEnum.UtilityBill)
            {
                model.PhoneNumber.ValidatePhone(ref response);

                model.TransactionAmount.ValidateTransactionAmount(ref product, ref response);

                model.PrivateId.ValidatePrivateId(ref response);

                if (!model.ServiceId.HasValue)
                {
                    response.Errors.Add("Service is required");
                }
                else
                {
                    var service = _serviceRepository.GetById(model.ServiceId.Value);
                    if(service==null)
                        response.Errors.Add("Service is required");
                }
            }

            else if (product.ProductType == ProductTypeEnum.Financial)
            {
                model.PhoneNumber.ValidatePhone(ref response);

                model.TransactionAmount.ValidateTransactionAmount(ref product, ref response);

                model.PrivateId.ValidatePrivateId(ref response);

                model.Iban.ValidateIban(ref response);
            }

            if (response.IsSuccess) // has 0 validation errors
            {
                var entity = new Transaction()
                {
                    PhoneNumber = model.PhoneNumber,
                    ProductType = model.ProductType,
                    TransactionAmount = model.TransactionAmount,
                    Iban = model.Iban,
                    ServiceId = model.ServiceId,
                    PrivateId = model.PrivateId,
                    CommisionAmount = model.TransactionAmount.CalculateCommision(ref product)
                };

                _transactionRepository.Create(entity);
            }

            return response;
        }

        public List<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        public Transaction GetById(long id)
        {
            return _transactionRepository.GetById(id);
        }
    }
}
