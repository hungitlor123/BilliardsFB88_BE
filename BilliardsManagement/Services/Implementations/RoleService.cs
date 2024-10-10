using BilliardsManagement.Entities;
using BilliardsManagement.Services.Interfaces;

namespace BilliardsManagement.Services.Implementations
{
    public class RoleService: IRoleService
    {
        private readonly BilliardsManagementContext _context;
        public RoleService(BilliardsManagementContext context)
        {
            _context = context;
            
        }
        public ICollection<Role> GetRoles()
        {
            var roles = _context.Roles.ToList();
            return roles;
        }
    }
}
