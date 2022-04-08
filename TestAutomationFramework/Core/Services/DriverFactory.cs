namespace Core.Services
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using System;
    using WebDriverManager;
    using WebDriverManager.DriverConfigs.Impl;

    internal static class DriverFactory
    {
        public static IWebDriver GetDriver(string browserType = "chrome")
        {
            IWebDriver driver;
                switch (browserType.ToLower())
                {
                    case "firefox":
                        {                           
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                            driver = new FirefoxDriver();
                            break;
                        }
                    case "edge":
                        {
                            new DriverManager().SetUpDriver(new EdgeConfig());
                            driver = new EdgeDriver();
                            break;
                        }
                    case "chrome":
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            driver = new ChromeDriver();
                            break;
                        }
                    default:
                        {
                        throw new ArgumentException("Incorrect browser value!");
                        }
                }
            return driver;
        }
    }
}
