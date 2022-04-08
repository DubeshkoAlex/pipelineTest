using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Core.Elements
{
    public class BaseElement
    {
        public IWebElement Element { get; set; }

        public BaseElement(IWebElement element)
        {
            Element = element;
        }  

        public BaseElement(By locator, WebDriverWait wait)
        {
            Element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

    }
}
