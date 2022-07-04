namespace Applications.Server.Repositories;

public interface IApplicationRepository : IBaseRepository<Application>
{
    Task<IEnumerable<Application>> GetForGrid();
    Task<IEnumerable<Application>> GetForGrid(Guid stageId);
}