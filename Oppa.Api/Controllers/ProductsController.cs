using Microsoft.AspNetCore.Mvc;
using Oppa.Data.Models;
using Oppa.Data.ViewModels;
using Oppa.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Oppa.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            var response = new ResponseModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(response);
                }

                _productsService.Create(model);

                response.StatusCode = HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessages.Add(e.Message);

                response.StatusCode = HttpStatusCode.BadRequest;

                return Ok(response);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateProductViewModel model)
        {
            var response = new ResponseModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(response);
                }

                var data = _productsService.GetById(id);

                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                _productsService.Update(model, data);

                response.StatusCode = HttpStatusCode.OK;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.ErrorMessages.Add(e.Message);

                response.StatusCode = HttpStatusCode.BadRequest;

                return Ok(response);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = new ResponseModel<List<Product>>();

            try
            {
                var data = _productsService.GetAll();

                if (data == null || !data.Any())
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

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var response = new ResponseModel<Product>();

            try
            {
                var data = _productsService.GetById(id);

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

        [HttpDelete("{id:int}")]

        public IActionResult Delete(int id)
        {
            var response = new ResponseModel();

            try
            {
                var data = _productsService.GetById(id);

                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                else
                {
                    _productsService.Delete(data);

                    response.StatusCode = HttpStatusCode.OK;

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

    }
}
