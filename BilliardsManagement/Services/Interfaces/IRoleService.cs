using BilliardsManagement.Entities;
using BilliardsManagement.Models.Creates;
using BilliardsManagement.Models.Update;
using BilliardsManagement.Models.Views;

namespace BilliardsManagement.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<RoleViewModel> GetRoles();

        RoleViewModel? GetRoleById(Guid id);
        void DeleteRole(Guid id);
        RoleViewModel? CreateRole(RoleCreateModel model);
        RoleViewModel? UpdateRole(Guid id,RoleUpdatePropertiesModel model);
        
        RoleViewModel? UpdateRole (RoleUpdateModel model);
    }
}
