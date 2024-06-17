using Microsoft.AspNetCore.Mvc;
using shop_management_system_api.Data;
using shop_management_system_api.Models;
using shop_management_system_api.Services;
using shop_management_system_api.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace shop_management_system_api.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            List<Employee> employees = _employeeService.GetAll();

            return employees;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            Employee employee = _employeeService.GetEmployeeById(id);

            return Ok(employee);
        }
    }
}