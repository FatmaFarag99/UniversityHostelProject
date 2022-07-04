namespace ApplicationSettings.Shared.ViewModels
{
    using System;

    public class ApplicationStageViewModel : BaseViewModel
    {
        public DateTime EndTime { get; set; } = DateTime.Today;
        public string EndTimeDate => EndTime.ToString("dd-MM-yyyy");

        public StageStatus StageStatus { get; set; }
        public bool IsResultSubmitted { get; set; }
    }
}