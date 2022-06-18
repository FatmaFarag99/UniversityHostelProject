namespace ApplicationSettings.Client.Components
{
    using System.Threading.Tasks;

    public partial class ApplicationSettingsComponent
    {
        private bool dataLoaded;
        public ApplicationSettingViewModel ApplicationSettingViewModel { get; set; } = new ApplicationSettingViewModel();

        protected override async Task OnInitializedAsync()
        {
            ApplicationSettingViewModel = await _applicationSettingHttpService.GetByIdAsync($"/api/applicationSettings");
            dataLoaded = true;
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                ApplicationSettingViewModel = await _applicationSettingHttpService.PutAsync("/api/applicationSettings", ApplicationSettingViewModel);
                _toastService.ShowSuccess("ApplicationSetting Edited Successfuly");
                StateHasChanged();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}