using DemoStore.WebApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoStore.WebApi
{
    [ApiController]
    [EntityValidation]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int employeeId)
        {
            var result = await _service.GetAsync(employeeId, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _service.GetListAsync(HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpGet]
        public async Task<IActionResult> GetPageAsync([FromQuery] PageParameter page)
        {
            var result = await _service.GetPageAsync(page, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] EmployeeDTO employee)
        {
            var result = await _service.AddAsync(employee, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpPost]
        public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<EmployeeDTO> employees)
        {
            var result = await _service.AddRangeAsync(employees, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeeDTO employee)
        {
            var result = await _service.UpdateAsync(employee, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int employeeId)
        {
            var result = await _service.DeleteAsync(employeeId, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }
    }
}
