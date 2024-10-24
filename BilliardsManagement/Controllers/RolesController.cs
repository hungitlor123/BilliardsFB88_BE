using BilliardsManagement.Models.Creates;
using BilliardsManagement.Models.Update;
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
        //HttpGet khong co request body
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
        public IActionResult CreateRole([FromForm]RoleCreateModel model)
        {
            var role = _roleService.CreateRole(model);
            if (role != null)
            {
                return StatusCode(201, role);
            }
            return StatusCode(400, "cute");
            
        }

        [HttpPatch]
        [Route("{id:guid}")]
        public IActionResult UpdateRole([FromRoute]Guid id,[FromForm] RoleUpdatePropertiesModel model)
        {
            var role = _roleService.UpdateRole(id, model);
            if (role != null)
            {
                return StatusCode(200, role);
            }

            return StatusCode(400, "cute");
        }
        
        [HttpPut]
        public IActionResult RoleUpdate([FromBody] RoleUpdateModel model)
        {
            var role = _roleService.UpdateRole(model);
            if (role != null)
            {
                return StatusCode(200, role);
            }

            return StatusCode(400, "cute");
        }
    }
}
