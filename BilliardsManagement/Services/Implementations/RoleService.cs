using BilliardsManagement.Entities;
using BilliardsManagement.Services.Interfaces;

namespace BilliardsManagement.Services.Implementations
{
    public class RoleService : IRoleService
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

        public Role? GetRoleById(Guid id)
        {
            //linQ
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            return role;
        }

        public void DeleteRole(Guid id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return;
            }
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public Role CreateRole(string name)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = name,
            };
            _context.Roles.Add(role);
            _context.SaveChanges();

            return role;
        }
    }
}