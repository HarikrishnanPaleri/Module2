using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDExam.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        public static IWebDriver? driver;

        [BeforeFeature(Order = 1)]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }

        [BeforeFeature(Order = 2)]
        public static void LogFileCreation()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [AfterFeature]
        public static void NavigateToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }
    }
}
