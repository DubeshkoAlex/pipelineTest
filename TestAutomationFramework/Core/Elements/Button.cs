using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Elements
{
    public class Button : BaseElement, IButton
    {
        public Button(IWebElement element) : base(element) { }

        public Button(By locator, WebDriverWait wait) : base(locator, wait) { }

        public void Click() => Element.Click();
        
        public string GetValue() =>
            Element.Text == "" ? Element.GetAttribute("value") : Element.Text;
            
    }
}
