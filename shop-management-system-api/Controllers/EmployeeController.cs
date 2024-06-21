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

        [HttpGet("all-employees")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            List<Employee> employees = await _employeeService.GetAll();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            Employee employee = await _employeeService.GetEmployeeById(id);

            if (employee == null) {

                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("active-employees")]

        public async Task<ActionResult<Employee>> GetActiveEmployees ()
        {
            List<Employee> employees = await _employeeService.GetActiveEmployees();

            if (employees == null) { 
            
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpPut]

        public async Task UpdateEmployee (Employee employee)
        {
            await _employeeService.UpdateEmployee(employee);
        }

        [HttpDelete]

        public async Task<ActionResult<Employee>> RemoveEmpoyeById (int id)
        {

            Employee result = await _employeeService.RemoveEmployeeById(id);

            if (result == null) {

                return NotFound();
            }

            return Ok("Deleted");
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            Employee newEmployee = await _employeeService.AddEmployee(employee);

            return Ok(newEmployee);
        }

        [HttpGet("employees-with-managers")]
        public async Task<ActionResult<List<EmployeeDTO>>> EmployeesWithManagers()
        {
            List<EmployeeDTO> employeeDTO = await _employeeService.EmployeesWithManagers();

            return Ok(employeeDTO);
        }
    }
}