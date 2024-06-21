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

        public async Task<ActionResult<List<Manager>>> GetAll ()
        {
            List<Manager> managers = await _managerService.GetAll();

            return Ok(managers);
        }


        [HttpGet("selected-info")]

        public async Task<ActionResult<ManagerDTO>> GetSelectedManagerInfo(int id)
        {
            ManagerDTO selectedInfo = await _managerService.GetSelectedManagerInfo(id);

            return Ok(selectedInfo);
        }

        [HttpPost]

        public async Task<ActionResult<Manager>> AddManager(Manager manager)
        {
            Manager newManager = await _managerService.AddManager(manager);

            return Ok(newManager);
        }

        [HttpGet]

        public async Task<ActionResult<Manager>> GetManagerById(int id)
        {
            Manager manager = await _managerService.GetManagerById(id);

            return Ok(manager);
        }
    }
}
