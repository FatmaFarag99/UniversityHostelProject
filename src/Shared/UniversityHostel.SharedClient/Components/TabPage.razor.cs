namespace UniversityHostel.SharedClient.Components
{
    using SmartUI.Forms;

    public partial class TabPage : BaseComponent
    {
        [CascadingParameter(Name = "ParentTapControl")]
        public TabControl ParentTapControl { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool Disabled { get; set; }

        protected override void OnInitialized()
        {
            if (ParentTapControl is null)
                throw new ArgumentNullException(nameof(ParentTapControl), "TabPage must exist within a TabControl");

            ParentTapControl.AddTapPage(this);

            base.OnInitialized();
        }
    }
}
