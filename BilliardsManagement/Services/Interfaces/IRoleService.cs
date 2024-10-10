using BilliardsManagement.Entities;

namespace BilliardsManagement.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<Role> GetRoles();
    }
}
