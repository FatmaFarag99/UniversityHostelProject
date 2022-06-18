namespace ApplicationSettings.Client.Components
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public partial class ApplicationStagesComponent
    {
        private IEnumerable<ApplicationStageViewModel> applicationStages;
        private bool dataLoaded;
        protected override async Task OnInitializedAsync() => await GetStagees();

        private async Task GetStagees()
        {
            try
            {
                applicationStages = await _applicationStagesHttpService.GetAsync("/api/ApplicationStages");
                dataLoaded = true;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
