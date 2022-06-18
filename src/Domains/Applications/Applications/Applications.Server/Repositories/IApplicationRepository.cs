namespace Applications.Server.Repositories;

public interface IApplicationRepository : IBaseRepository<Application>
{
    Task<IEnumerable<Application>> GetForGrid();
}
