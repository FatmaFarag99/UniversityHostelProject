namespace Applications.Server.Repositories;

using ApplicationSettings.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Application>> GetForGrid() => await _table.Include(e => e.User)
        .Include(e => e.BasicInformation).ThenInclude(e => e.Residence)
        .Include(e => e.BasicInformation).ThenInclude(e => e.Faculty).ToListAsync();

    public async Task<IEnumerable<Application>> GetForGrid(Guid stageId) => await _table.Include(e => e.User)
        .Include(e => e.BasicInformation).ThenInclude(e => e.Residence)
        .Include(e => e.BasicInformation).ThenInclude(e => e.Faculty)
        .Where(a => a.ApplicationStageId == stageId).ToListAsync();

    public override async Task<Application> GetByIdAsync(Guid id) => await _table.Where(e => e.Id == id)
        .Include(e => e.Documents).ThenInclude(e => e.Document)
        .Include(e => e.BasicInformation).ThenInclude(e => e.Residence)
        .Include(e => e.BasicInformation).ThenInclude(e => e.Faculty).SingleOrDefaultAsync();
}
