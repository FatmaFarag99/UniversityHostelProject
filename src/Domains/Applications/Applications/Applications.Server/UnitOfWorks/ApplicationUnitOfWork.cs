namespace Applications.Server.UnitOfWorks;

using ApplicationSettings.Server.UnitOfWorks;
using ApplicationSettings.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ApplicationUnitOfWork : BaseUnitOfWork<Application, ApplicationViewModel>, IApplicationUnitOfWork
{
    private readonly IApplicationRepository _repository;
    private readonly IApplicationStageUnitOfWork _applicationStageUnitOfWork;

    public ApplicationUnitOfWork(IApplicationRepository repository, IApplicationStageUnitOfWork applicationStageUnitOfWork, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _applicationStageUnitOfWork = applicationStageUnitOfWork;
    }

    public async Task<IEnumerable<ApplicationGridViewModel>> ReadForGrid()
    {
        ApplicationStageViewModel lastStage = await _applicationStageUnitOfWork.ReadLastStage();

        IEnumerable<Application> applications = await _repository.GetForGrid(lastStage.Id);

        return applications.Select(e => new ApplicationGridViewModel
        {
            Id = e.Id,
            DisplayOrder = e.DisplayOrder,
            CreationDate = e.CreationDate,
            StudentName = e.BasicInformation.Name,
            PlaceOfBirth = e.BasicInformation.PlaceOfBirth,
            FullAddress = e.BasicInformation.FullAddress,
            FatherJob = e.BasicInformation.FatherJob,
            GuardianName = e.BasicInformation.GuardianName,
            GuardianRelationship = e.BasicInformation.GuardianRelationship,
            IsSpecialNeeds = e.BasicInformation.IsSpecialNeeds,
            IsFamilyOutside = e.BasicInformation.IsFamilyOutside,
            Degree = e.BasicInformation.Degree,
            PreviousGPA = e.BasicInformation.PreviousGPA,
            Level = e.BasicInformation.Level,
            Gender = e.BasicInformation.Gender,
            HousingType = e.BasicInformation.HousingType,
            ResidenceName = e.BasicInformation.Residence?.Name,
            FacultyName = e.BasicInformation.Faculty?.Name,
            Status = e.Status
        });
    }

    public async Task<ApplicationViewModel> Reject(ApplicationViewModel application)
    {
        Application applicationFromDb = await _repository.GetByIdAsync(application.Id);
        if (applicationFromDb is null)
            throw new Exception("Application doesn't exist");

        if (!applicationFromDb.Status.Equals(ApplicationStatus.Pending))
            throw new Exception("Can not perform operation twice");
        
        applicationFromDb.Status = ApplicationStatus.Rejected;
        await _repository.EditAsync(applicationFromDb);
        await _context.SaveChangesAsync();

        return application;
    }
    public async Task<ApplicationViewModel> Accept(ApplicationViewModel application)
    {
        Application applicationFromDb = await _repository.GetByIdAsync(application.Id);
        if (applicationFromDb is null)
            throw new Exception("Application doesn't exist");

        if (!applicationFromDb.Status.Equals(ApplicationStatus.Pending))
            throw new Exception("Can not perform operation twice");

        applicationFromDb.Status = ApplicationStatus.Accepted;
        await _repository.EditAsync(applicationFromDb);
        await _context.SaveChangesAsync();

        return application;
    }
}
