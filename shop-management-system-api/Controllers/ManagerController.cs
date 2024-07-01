using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_management_system_api.Models;
using shop_management_system_api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace shop_management_system_api.Controllers
{
    [Route("manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("all-managers")]

        public async Task<ActionResult<List<Manager>>> GetAll()
        {
            List<Manager> managers = await _managerService.GetAll();

            return Ok(managers);
        }

        [HttpPost("add")]

        public async Task<ActionResult<Manager>> AddManager(Manager manager)
        {
            Manager newManager = await _managerService.AddManager(manager);

            return Ok(newManager);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Manager>> GetManagerById(int id)
        {
            Manager manager = await _managerService.GetManagerById(id);

            return Ok(manager);
        }

        [HttpGet("managers-with-employees")]
        public async Task<ActionResult<List<Manager>>> ManagersWithEmployees()
        {
            List<Manager> managersWithEmployees = await _managerService.ManagersWithEmployees();

            return Ok(managersWithEmployees);
        }

        [HttpPost("manager-id")]

        public async Task<int> GetManagerIdByName(Manager manager)
        {
            int managerId = await _managerService.GetManagerId(manager);

            return managerId;
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Manager>> RemoveManagerById(int id)
        {

            Manager manager = await _managerService.RemoveManagerById(id);

            if (manager == null) {

                return NotFound();
           
            }

            return Ok("Deleted!");

        }
    }
}
