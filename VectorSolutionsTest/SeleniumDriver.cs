using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VectorSolutionsTest
{
    public class SeleniumDriver
    {
        public static IWebDriver Driver { get; set; }

        public static void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incognito");
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
        }
    }
}
