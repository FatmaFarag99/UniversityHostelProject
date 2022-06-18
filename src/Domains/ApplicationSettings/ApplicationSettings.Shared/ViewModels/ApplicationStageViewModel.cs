namespace ApplicationSettings.Shared.ViewModels
{
    using System;

    public class ApplicationStageViewModel : BaseViewModel
    {
        public DateTime EndTime { get; set; } = DateTime.Now;

        public StageStatus StageStatus { get; set; }
    }
}
