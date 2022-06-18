namespace ApplicationSettings.Client.Components
{
    using System;
    using System.Threading.Tasks;

    public partial class ApplicationStageFormView
    {
        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string SystemFeatureTypeParameter { get; set; }

        private SystemFeatureType systemFeatureType = SystemFeatureType.Add;
        private ApplicationStageViewModel applicationStage = new ApplicationStageViewModel();

        protected override async Task OnInitializedAsync()
        {
            systemFeatureType = (SystemFeatureType)Enum.Parse(typeof(SystemFeatureType), SystemFeatureTypeParameter, true);

            if (systemFeatureType.Equals(SystemFeatureType.Add))
                return;

            applicationStage = await _applicationStagesHttpService.GetByIdAsync($"/api/ApplicationStages/{Id.ToString()}");
        }
    }
}
