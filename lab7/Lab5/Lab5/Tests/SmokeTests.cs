using NUnit.Framework;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace Lab5.Tests
{
    [TestFixture]
    public class SmokeTests
    {
        private IWebDriver driver;
        private Steps.Steps steps = new Steps.Steps();
        private static string USERNAME = StringUtils.DataStringUsername;
        private static string PASSWORD = StringUtils.DataStringPassword;
        private static string INCORRECT_CITY = StringUtils.DataStringIncorrectCity;
        private static string EERROR_TEXT = StringUtils.DataStringError;

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void OneCanLoginBooking()
        {
            Logger.InitLogger();
            try
            {
                steps.LoginBooking(USERNAME, PASSWORD);
                Assert.AreEqual(USERNAME, steps.GetLoggedInUserName());
            }

            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = driver.TakeScreenshot();
                var filePath = ".//" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        [Test]
        public void EnterIncorrecCity()
        {
            Logger.InitLogger();
            try
            {
                Logger.InitLogger();
                steps.SearchingError(INCORRECT_CITY);
                Assert.AreEqual(EERROR_TEXT, steps.SearchIncorrectCity());
            }

            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = driver.TakeScreenshot();
                var filePath = ".//" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
    }
}
