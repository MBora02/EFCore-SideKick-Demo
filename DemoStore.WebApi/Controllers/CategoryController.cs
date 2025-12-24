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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int categoryId)
        {
            var result = await _service.GetAsync(categoryId, HttpContext.RequestAborted);
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
        public async Task<IActionResult> AddAsync([FromBody] CategoryDTO category)
        {
            var result = await _service.AddAsync(category, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpPost]
        public async Task<IActionResult> AddRangeAsync([FromBody] IEnumerable<CategoryDTO> categories)
        {
            var result = await _service.AddRangeAsync(categories, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryDTO category)
        {
            var result = await _service.UpdateAsync(category, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int categoryId)
        {
            var result = await _service.DeleteAsync(categoryId, HttpContext.RequestAborted);
            return Ok(new {Success = true,Data = result});
        }
    }
}
