namespace Core.Services
{
    using Configuration;
    using Configuration.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public static class BrowserPool
    {
        private static Dictionary<string, Browser> browsersPool = new Dictionary<string, Browser>();

        public static void CreateBrowser()
        {
            browsersPool.Add(TestContext.CurrentContext.Test.ID, new Browser(ConfigurationManager.GetConfiguration<BrowserSettingsModel>()));
        }
        public static Browser GetBrowser()
        {
            if (!browsersPool.ContainsKey(TestContext.CurrentContext.Test.ID))
            {
                throw new NullReferenceException("There is no such browser with current ID!");
            }
            return browsersPool[TestContext.CurrentContext.Test.ID]; 
        }
        public static void CloseBrowser()
        {
            browsersPool.GetValueOrDefault(TestContext.CurrentContext.Test.ID).Dispose();
            browsersPool.Remove(TestContext.CurrentContext.Test.ID);
        }
    }
}