using Microsoft.AspNetCore.Mvc;
using Oppa.Data;
using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using Oppa.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Oppa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : BaseController
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ApplicationDbContext context;
        public TransactionsController(ITransactionsService transactionsService, ApplicationDbContext context)
        {
            _transactionsService = transactionsService;
            this.context = context;
        }

        [HttpPost]
        public IActionResult Create(CreateTransactionViewModel model)
        {
            var response = new ResponseModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    // add validation errors to response.ErrorMessages
                    return BadRequest(response);
                }

                var serviceResponse = _transactionsService.Create(model);

                if (serviceResponse.IsSuccess)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.ErrorMessages.AddRange(serviceResponse.Errors);
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.ErrorMessages.Add(e.Message);

                response.StatusCode = HttpStatusCode.BadRequest;

                return Ok(response);
            }
        }
    }
}
