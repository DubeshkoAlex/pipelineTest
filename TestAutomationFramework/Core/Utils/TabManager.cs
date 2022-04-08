namespace Core.Services
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public class TabManager
    {
        private IDictionary<int,string> tabs = new Dictionary<int, string>();
        private IWebDriver driver;
        public TabManager(IWebDriver driver)
        {
            this.driver = driver;
            tabs.Add(1, this.driver.CurrentWindowHandle);     
        }

        public void SwitchToTab(int tabNumber) => driver.SwitchTo().Window(tabs[tabNumber]);
        public void OpenNewTab()
        {
            SwitchToTab(tabs.Count);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open()");
            tabs.Add(tabs.Count + 1, driver.WindowHandles.Last());
            SwitchToTab(tabs.Count);
        }
    }
}
