namespace ApplicationSettings.Client.Components
{
    using System;
    using System.Threading.Tasks;

    public partial class BaseApplicationStageComponent
    {
        [Parameter]
        public ApplicationStageViewModel ApplicationStageViewModel { get; set; } = new ApplicationStageViewModel();
        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

        private async Task HandleValidSubmit()
        {
            try
            {
                string successMessage = string.Empty;
                if (SystemFeatureType.Equals(SystemFeatureType.Add))
                {
                    ApplicationStageViewModel = await _applicationStagesHttpService.PostAsync("/api/ApplicationStages", ApplicationStageViewModel);
                    successMessage = "Residence Added Successfuly";
                }
                else if (SystemFeatureType.Equals(SystemFeatureType.Edit))
                {
                    ApplicationStageViewModel = await _applicationStagesHttpService.PutAsync("/api/ApplicationStages", ApplicationStageViewModel);
                    successMessage = "Residence Edited Successfuly";
                }
                _toastService.ShowSuccess(successMessage);
                
                _navigationManager.NavigateTo("/ApplicationStages");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
