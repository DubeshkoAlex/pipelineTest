using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Core.Elements
{
    public class ComboBox : BaseElement, IComboBox
    {
        public ComboBox(IWebElement element) : base(element) { }

        public ComboBox(By locator, WebDriverWait wait) : base(locator, wait) { }

        public List<string> GetList() =>
            Element.FindElements(By.XPath("//option")).Select(x=>x.Text).ToList();
        
        public void ClickOn(string item) =>
            Element.FindElement(By.XPath($"//*[contains(text(),'{item}')]")).Click();
        
    }
}
