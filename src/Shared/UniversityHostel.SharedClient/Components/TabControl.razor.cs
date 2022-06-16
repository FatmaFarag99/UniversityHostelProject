namespace UniversityHostel.SharedClient.Components
{
    using SmartUI.Forms;
    using System.Collections.Generic;

    public partial class TabControl : BaseComponent
    {

        private LinkedList<TabPage> tapPages = new LinkedList<TabPage>();
        public TabPage ActiveTab => activeTabNode?.Value;

        private LinkedListNode<TabPage> activeTabNode;
        private TabFooter tabFooter;
        private TabRequestArgs tabRequestArgs = new TabRequestArgs();

        protected override void OnInitialized()
        {
            tabRequestArgs.ActivateNext += ActiveNext;
            tabRequestArgs.ActivatePrevious += ActivePrevious;

            base.OnInitialized();
        }
        internal void AddTapPage(TabPage tabPage)
        {
            tapPages.AddLast(tabPage);
            if (tapPages.Count == 1)
                activeTabNode = tapPages.First;

            StateHasChanged();
        }
        internal void AddTapFooter(TabFooter tabFooterTemplate)
        {
            tabFooter = tabFooterTemplate;

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
            activeTabNode = tapPages.Find(tabPage);
        }
        private void ActiveNext()
        {
            if (activeTabNode.Next == null)
                return;

            activeTabNode = activeTabNode.Next;
        }
        private void ActivePrevious()
        {
            if (activeTabNode.Previous == null)
                return;

            activeTabNode = activeTabNode.Previous;
        }

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string CssClass { get; set; }
        [Parameter] public string Id { get; set; }
    }
}
