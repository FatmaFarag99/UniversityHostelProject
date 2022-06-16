namespace UniversityHostel.SharedClient.Components
{
    using SmartUI.Forms;

    public partial class TabPage : BaseComponent
    {
        [CascadingParameter(Name = "ParentTapControl")]
        public TabControl ParentTabControl { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool Disabled { get; set; }

        [Parameter] public Action OnActive { get; set; }

        protected override void OnInitialized()
        {
            if (ParentTabControl is null)
                throw new ArgumentNullException(nameof(ParentTabControl), "TabPage must exist within a TabControl");

            ParentTabControl.AddTabPage(this);

            base.OnInitialized();
        }
    }
}