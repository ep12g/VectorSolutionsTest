using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace VectorSolutionsTest
{
    public static class SeleniumActions
    {
        public static void Click(By element, TimeSpan time)
        {
            var click = new WebDriverWait(SeleniumDriver.Driver, time);
            click.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            click.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element)).Click();
        }

        public static void Scroll(By element)
        {
            var actions = new Actions(SeleniumDriver.Driver);
            actions.MoveToElement(SeleniumDriver.Driver.FindElement(element));
            actions.Perform();
        }

        public static void Type(By element, string text, TimeSpan time)
        {
            var type = new WebDriverWait(SeleniumDriver.Driver, time);
            type.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            IWebElement input = type.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            input.Click();
            input.Clear();
            input.SendKeys(text);
        }

        public static string GetText(By element, TimeSpan time)
        {
            var text = new WebDriverWait(SeleniumDriver.Driver, time);
            text.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            IWebElement webelement = text.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
            return webelement.Text;
            
        }

        public static void Screenshot(string filename)
        {
            Screenshot ss = ((ITakesScreenshot)SeleniumDriver.Driver).GetScreenshot();
            ss.SaveAsFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + filename + ".png", ScreenshotImageFormat.Png);
        }

        public static void SaveTextToFile(By element, string filename)
        {
            File.WriteAllTextAsync(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + filename + ".txt", SeleniumDriver.Driver.FindElement(element).Text);
        }

        public static void SwitchToFrame(By element, TimeSpan time)
        {
            var favoritesFrame = new WebDriverWait(SeleniumDriver.Driver, time);
            favoritesFrame.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            favoritesFrame.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(element));
        }

        public static bool IsElementVisible(By element, TimeSpan time)
        {
            var sportsselectionisvisible = new WebDriverWait(SeleniumDriver.Driver, time);
            sportsselectionisvisible.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return sportsselectionisvisible.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element)).Displayed;
        }

    }
}
