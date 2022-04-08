namespace Core.Services
{
    using Configuration.Models;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;

    public class Browser : IDisposable
    {
        private IWebDriver driver;
        private TabManager tabManager;

        public Browser(BrowserSettingsModel browserSettings) 
        { 
            driver = DriverFactory.GetDriver(browserSettings.BrowserName);
            tabManager = new TabManager(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(browserSettings.ImplicitWait);
            driver.Url = browserSettings.BaseUrl;
        }

        protected IWebElement FindElement(By by) => driver.FindElement(by);
        protected IReadOnlyList<IWebElement> FindElements(By by) => driver.FindElements(by);
        public void GoToUrl(string url) => driver.Navigate().GoToUrl(url);
        public void OpenInFullScreen() => driver.Manage().Window.Maximize();
        public void RefreshPage() => driver.Navigate().Refresh();
        protected void ExecuteJsScript(string script) => ((IJavaScriptExecutor)driver).ExecuteScript(script);
        public void SwitchToTab(int tabNumber) => tabManager.SwitchToTab(tabNumber);
        public void OpenNewTab() => tabManager.OpenNewTab();
        public void AddItemToLocalStorage(string key, string value)
        {
            var script = string.Format($"localStorage.setItem({key},{value})");
            ExecuteJsScript(script);
        }
        public string GetCurrentUrl() => driver.Url;
        public void Dispose() => driver.Dispose();
    }
}
