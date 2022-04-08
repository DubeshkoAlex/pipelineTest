using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.IO;

namespace Core.Utils
{
    static class ScreenshotTaker
    {
        private const int ScreenHeight = 923;
        private const int BorderIndent = 10;

        public static void MakeScreenshot(IWebDriver driver)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string fileName = DateTime.Now.ToLocalTime().ToString().Replace(":","-");
            string fullPath = $@"{Environment.CurrentDirectory}\screenshots\{fileName}.jpeg";
            screenshot.SaveAsFile(fullPath);
            TestContext.AddTestAttachment(fullPath);
        }

        public static void MakeMarkedScreenshot(IWebDriver driver, IWebElement element)
        {
            MoveToElement(driver, element);

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            Image image;

            using (var ms = new MemoryStream(screenshot.AsByteArray))
            {
                image = Image.FromStream(ms);
            }

            Graphics graphics = Graphics.FromImage(image);

            int x = element.Location.X;

            var countOfScreens = element.Location.Y / ScreenHeight;  
            countOfScreens = countOfScreens < 1 ? 1 : countOfScreens;

            int y = element.Location.Y - (--countOfScreens * ScreenHeight);

            int elementWidth = element.Size.Width;
            int elementHeight = element.Size.Height;


            var frame = new Point[] { new Point(x - BorderIndent,y - BorderIndent),
                new Point(x - BorderIndent, y + elementHeight + BorderIndent),
                new Point(x + elementWidth + BorderIndent, y + elementHeight + BorderIndent),
                new Point(x + elementWidth + BorderIndent, y - BorderIndent) };

            var pen = new Pen(Brushes.Red, 5);

            graphics.DrawPolygon(pen, frame);
           
            string fileName = DateTime.Now.ToLocalTime().ToString();
            string fullPath = $@"{Environment.CurrentDirectory}\screenshots\{fileName}.jpeg";
            image.Save(fullPath);

            TestContext.AddTestAttachment(fullPath);
        }

        private static void MoveToElement(IWebDriver driver, IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
