using BilliardsManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilliardsManagement.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
           _roleService = roleService;
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRoleById([FromRoute]Guid id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound("Khong co");
            }
            return Ok(role);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRole([FromRoute] Guid id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }

        [HttpPost]
        [Route("create-role")]
        public IActionResult CreateRole(string name)
        {
            var role = _roleService.CreateRole(name);
            return Ok(role);
            
        }
    }
}
