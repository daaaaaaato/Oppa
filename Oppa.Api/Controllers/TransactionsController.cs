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

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new ResponseModel<List<Transaction>>();

            try
            {
                var data = _transactionsService.GetAll();

                if(data==null || !data.Any())
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = data;
                    return Ok(response);
                }
            }
            catch(Exception e)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add(e.Message);
                return BadRequest(response);
            }
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            var response = new ResponseModel<Transaction>();

            try
            {
                var data = _transactionsService.GetById(id);

                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                else
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Data = data;
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ErrorMessages.Add(e.Message);
                return BadRequest(response);
            }
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
