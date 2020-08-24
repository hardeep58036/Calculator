using System;
using System.Collections.Generic;
using CalculatorApi.DBContext;
using CalculatorApi.Model;
using CalculatorApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CalculatorApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculatorService _service;
        private readonly IActionContextAccessor _accessor;
        private readonly IDataRepository<Audit> _dataRepository;

        public CalculateController(ICalculatorService service, IDataRepository<Audit> dataRepository ,IActionContextAccessor accessor)
        {
            _service = service;
            _dataRepository = dataRepository;
            _accessor = accessor;
        }
       
        // POST: api/Calculate
        [HttpPost]
        public IActionResult Post([FromBody] Calculate model)
        {
            //Store the audit entry
            _dataRepository.Add(new Audit { IPAddress = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString(), Date = DateTime.UtcNow });

            double result = 0;
            switch(model.Operator)
            {
                case '+': result = _service.Add(model.FirstNumber, model.SecondNumber); break;
                case '-': result = _service.Subtract(model.FirstNumber, model.SecondNumber); break;
                case '*': result = _service.Multiply(model.FirstNumber, model.SecondNumber); break;
                case '/': result = _service.Divide(model.FirstNumber, model.SecondNumber); break;
                case '%': result = _service.Remainder(model.FirstNumber, model.SecondNumber); break;
                default:
                    return BadRequest($"operator {model.Operator} not supported");
            }
            return Ok(result);
        }


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Audit> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        /* NOTE: 
         * We can add separate endpoints for each operation as well.
         * I added a single one as it is easy to maintain client calls from UI application
         * */
    }
}
