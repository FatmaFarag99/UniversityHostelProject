namespace Applications.Server.Entities;

using Account.Server.Entities;
using Applications.Shared.Enums;

public class Application : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public ApplicationStatus Status { get; set; }
    public bool IsComplate => Step.Equals(ApplicationStep.Documents);
    public ApplicationStep Step { get; set; }
}