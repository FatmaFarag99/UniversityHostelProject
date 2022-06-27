namespace ApplicationSettings.Server.UnitOfWorks;

public interface IApplicationStageUnitOfWork : IBaseUnitOfWork<ApplicationStage, ApplicationStageViewModel>
{
    Task<ApplicationStageViewModel> ReadLastStage();
    Task<ApplicationStageViewModel> SubmitStageResults(Guid stageId);
}