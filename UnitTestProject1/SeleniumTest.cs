using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CapstoneTests
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void SearchHomePage_Details()
        {
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {
                var url = "http://localhost:60349/";
                chromeDriver.Navigate().GoToUrl(url);

                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));

                var search = chromeDriver.FindElement(By.Name("picture"));

                search.Click();

                var resultStats = chromeDriver.FindElement(By.Id("park-detail"));

                Assert.IsTrue(resultStats.Text.Contains("Location"));
                Assert.IsTrue(resultStats.Text.Contains("Climate"));
                Assert.IsTrue(resultStats.Text.Contains("Entry"));

                chromeDriver.Close();
            }


        }

        [TestMethod]
        public void Search_SurveyResults()
        {
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {
                var url = "http://localhost:60349/Survey/SurveyResults";
                chromeDriver.Navigate().GoToUrl(url);

                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));


                var resultStats = chromeDriver.FindElement(By.Id("resultsTable"));

                Assert.IsTrue(resultStats.Text.Contains("Park Name"));
                Assert.IsTrue(resultStats.Text.Contains("Number of Votes"));


                chromeDriver.Close();
            }


        }

    }
}
