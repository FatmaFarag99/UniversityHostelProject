namespace UniversityHostel.SharedClient.Components
{
    using SmartUI.Forms;
    using System.Threading.Tasks;

    public partial class TabPage : BaseComponent
    {
        [CascadingParameter(Name = "ParentTapControl")]
        public TabControl ParentTabControl { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment TitleTemplate { get; set; }
        [Parameter] public RenderFragment BodyTemplate { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public EventCallback OnActive { get; set; }

        public override Task SetParametersAsync(ParameterView parameters)
        {
            if(BodyTemplate is not null)
            {
                ChildContent = BodyTemplate;
            }
            if(TitleTemplate is null)
            {
                TitleTemplate = (builder) => builder.AddContent(1, Title);
            }
            return base.SetParametersAsync(parameters);
        }
        protected override void OnInitialized()
        {
            if (ParentTabControl is null)
                throw new ArgumentNullException(nameof(ParentTabControl), "TabPage must exist within a TabControl");

            ParentTabControl.AddTabPage(this);

            base.OnInitialized();
        }
    }
}