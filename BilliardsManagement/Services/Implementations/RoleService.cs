using BilliardsManagement.Entities;
using BilliardsManagement.Models.Creates;
using BilliardsManagement.Models.Update;
using BilliardsManagement.Models.Views;
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

        public ICollection<RoleViewModel> GetRoles()
        {
            var roles = _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreateAt = x.CreateAt
                
            }).ToList();
            
            return roles;
        }

        public RoleViewModel? GetRoleById(Guid id)
        {
            //linQ
            var role = _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreateAt = x.CreateAt

            }).FirstOrDefault(x => x.Id.Equals(id));
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

        // public Role CreateRole(string name)
        // {
        //     var role = new Role
        //     {
        //         Id = Guid.NewGuid(),
        //         Name = name,
        //     };
        //     _context.Roles.Add(role);
        //     _context.SaveChanges();
        //
        //     return role;
        // }

        //tạo mới thành công thì trả về đối tượng vừa được tạo mới kèm theo status 201
        public RoleViewModel? CreateRole(RoleCreateModel model)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CreateAt = DateTime.UtcNow
            };

            _context.Roles.Add(role);
            //biến result sẽ trả về số dòng được thực thi
            var result = _context.SaveChanges();

            return result == 1 ? GetRoleById(role.Id) : null!;
        }

        public RoleViewModel? UpdateRole(Guid id, RoleUpdatePropertiesModel model)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(id));
            if (role == null)
            {
                return null;
            }

            if (model.Name != null)
            {
                role.Name = model.Name;
            }

            _context.Roles.Update(role);
            var result = _context.SaveChanges();

            return result == 1 ? GetRoleById(id) : null;
        }

        public RoleViewModel? UpdateRole(RoleUpdateModel model)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id.Equals(model.Id));
            if (role == null)
            {
                return null;
            }

            role.Name = model.Name;
            role.CreateAt = model.CreateAt;

            _context.Roles.Update(role);

            var result = _context.SaveChanges();

            return result == 1 ? GetRoleById(role.Id) : null!;
        }
    }
}