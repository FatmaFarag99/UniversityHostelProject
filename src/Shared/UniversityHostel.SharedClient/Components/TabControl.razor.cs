namespace UniversityHostel.SharedClient.Components
{
    using SmartUI.Forms;
    using System.Collections.Generic;

    public partial class TabControl : BaseComponent
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string CssClass { get; set; }
        [Parameter] public string Id { get; set; }

        private List<TabPage> tabPages = new List<TabPage>();
        public TabPage ActiveTab { get; set; }

        public void AddTabPage(TabPage tabPage)
        {
            tabPages.Add(tabPage);
            if (tabPages.Count == 1)
                ActiveTab = tabPage;

            StateHasChanged();
        }

        private string GetNavLinkCssClass(TabPage tabPage)
        {
            string cssClass = ActiveTab == tabPage ? "active " : "";
            cssClass += tabPage.Disabled ? "disabled " : "";

            return cssClass;
        }

        private void ActivePage(TabPage tabPage)
        {
            ActiveTab = tabPage;
            tabPage.OnActive?.Invoke();
        }
    }
}