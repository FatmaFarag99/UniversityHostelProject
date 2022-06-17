namespace ApplicationSettings.Client.Components
{
    using System.Threading.Tasks;

    public partial class ApplicationSettingsComponent
    {
        public ApplicationSettingViewModel ApplicationSettingViewModel { get; set; } = new ApplicationSettingViewModel();

        protected override async Task OnInitializedAsync()
        {
            ApplicationSettingViewModel = await _applicationSettingHttpService.GetByIdAsync($"/api/applicationSettings");
        }

        private async Task HandleValidSubmit()
        {
            ApplicationSettingViewModel = await _applicationSettingHttpService.PutAsync("/api/applicationSettings", ApplicationSettingViewModel);
            _toastService.ShowSuccess("ApplicationSetting Edited Successfuly");
            StateHasChanged();
        }
    }
}