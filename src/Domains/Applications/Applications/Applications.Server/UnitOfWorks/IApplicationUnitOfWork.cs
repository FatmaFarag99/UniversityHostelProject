namespace Applications.Server.UnitOfWorks;

public interface IApplicationUnitOfWork : IBaseUnitOfWork<Application, ApplicationViewModel>
{
    Task<IEnumerable<ApplicationGridViewModel>> ReadForGrid();
    Task<ApplicationViewModel> Reject(ApplicationViewModel application);
    Task<ApplicationViewModel> Accept(ApplicationViewModel application);
}
