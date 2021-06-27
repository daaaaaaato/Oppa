using Microsoft.AspNetCore.Mvc;
using Oppa.Data.Enums;
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
    public class ServicesController : BaseController
    {

        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpPost]
        public IActionResult Create(CreateServiceViewModel model)
        {
            var response = new ResponseModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    // add validation errors to response.ErrorMessages
                    return BadRequest(response);
                }

                _servicesService.Create(model);

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
        public IActionResult Update(int id, [FromBody] UpdateServiceViewModel model)
        {
            var response = new ResponseModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    // add validation errors to response.ErrorMessages
                    return BadRequest(response);
                }

                var data = _servicesService.GetById(id);

                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }

                _servicesService.Update(model, data);

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
        public IActionResult GetAll([FromQuery] ProductTypeEnum? productType)
        {
            var response = new ResponseModel<List<Service>>();

            try
            {
                var data = _servicesService.GetAll(productType);

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
            var response = new ResponseModel<Service>();

            try
            {
                var data = _servicesService.GetById(id);

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
                var data = _servicesService.GetById(id);

                if (data == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(response);
                }
                else
                {
                    _servicesService.Delete(data);

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
