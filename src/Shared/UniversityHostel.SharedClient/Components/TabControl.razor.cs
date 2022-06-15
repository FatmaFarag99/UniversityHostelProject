namespace UniversityHostel.SharedClient.Components
{
    using SmartUI.Forms;
    using System.Collections.Generic;

    public partial class TabControl : BaseComponent
    {

        private List<TabPage> tapPages = new List<TabPage>();
        public TabPage ActiveTab { get; set; }

        public void AddTapPage(TabPage tabPage)
        {
            tapPages.Add(tabPage);
            if (tapPages.Count == 1)
                ActiveTab = tabPage;

            StateHasChanged();
        }

        private string GetNavLinkCssClass(TabPage tabPage)
        {
            string cssClass = ActiveTab == tabPage ? "active " : "";
            cssClass += tabPage.Disabled ? "disabled " : "";

            return cssClass;
        }

        private void ActivePage(TabPage tabPage) => ActiveTab = tabPage;


        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string CssClass { get; set; }
        [Parameter] public string Id { get; set; }
    }
}
