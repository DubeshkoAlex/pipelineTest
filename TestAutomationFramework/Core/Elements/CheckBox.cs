using Core.Interfases;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Elements
{
    public class CheckBox : BaseElement, ICheckBox
    {
        public CheckBox(IWebElement element) : base(element) { }

        public CheckBox(By locator, WebDriverWait wait) : base(locator, wait) { }

        public void Set(bool state)
        {
            if(state != (Element.GetAttribute("aria-checked") == "true"))
            {
                Element.Click();
            }
        }
  
        public bool GetState() => Element.GetAttribute("aria-checked") == "true";
      
    }
}
