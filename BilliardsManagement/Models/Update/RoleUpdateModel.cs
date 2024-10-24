namespace BilliardsManagement.Models.Update;

public class RoleUpdateModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}