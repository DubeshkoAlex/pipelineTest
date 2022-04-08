using Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Elements
{
    public class Textbox : BaseElement, ITextBox
    {
        public Textbox(IWebElement element) : base(element) { }

        public Textbox(By locator, WebDriverWait wait) : base(locator, wait) { }

        public void SendKeys(string text) => Element.SendKeys(text);
        
        public string GetValue() => Element.Text;
        

    }
}
