using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EmployeeController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public IActionResult EmployeeList()
        {
            var _employees = _dataContext.Employees.ToList();
            var employeeModels = _mapper.Map<List<ResultEmployeeDTO>>(_employees);
            return View(employeeModels);
        }
    }
}
