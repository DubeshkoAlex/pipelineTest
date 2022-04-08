using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Elements
{
    public class Link : BaseElement, ILink
    {
        public Link(IWebElement element) : base(element) { }

        public Link(By locator, WebDriverWait wait) : base(locator, wait) { }

        public void Click() => Element.Click(); 
        
        public string GetValue() => Element.Text;

        public string GetUrl() => Element.GetAttribute("href");
       
    }
}
