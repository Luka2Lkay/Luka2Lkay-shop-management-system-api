using Microsoft.AspNetCore.Mvc;
using shop_management_system_api.Data;
using shop_management_system_api.Services;

namespace shop_management_system_api.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService) { 
        
            _employeeService = employeeService;
        
        }


    
    }
}
