using NUnit.Framework;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using Lab5.Driver;
using System.Drawing.Imaging;

namespace Lab5.Tests
{
    [TestFixture]
    public class SmokeTests
    {
        private IWebDriver Driver = DriverInstance.GetInstance();
        private Steps.Steps steps = new Steps.Steps();
        private static string USERNAME = StringUtils.DataStringUsername;
        private static string PASSWORD = StringUtils.DataStringPassword;
        private static string INCORRECT_CITY = StringUtils.DataStringIncorrectCity;
        private static string EERROR_TEXT = StringUtils.DataStringError;
        private static string CITY = StringUtils.DataStringCity;
        private static string ERROR_DATE_TEXT = StringUtils.DataStringErrorDate;
        private static string ERROR_DATE_TEXT_END = StringUtils.DataStringErrorDateEnd;

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

        //Проверка авторизации пользователя
        [Test]
        public void OneCanLoginBooking()
        {
            Logger.InitLogger();
            try
            {
                steps.LoginBooking(USERNAME, PASSWORD);                
                Assert.AreEqual(USERNAME, steps.GetLoggedInUserName());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        //Ввод несуществующего места назначения
        [Test]
        public void EnterIncorrecCity()
        {
            Logger.InitLogger();
            try
            {                
                steps.SearchingError(INCORRECT_CITY);
                Assert.AreEqual(EERROR_TEXT.Replace("\\r", "").Replace("\\n", ""), steps.SearchIncorrectCity());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot(); 
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        // Выбор даты заезда из прошедшего времени или текущим днем
        [Test]
        public void ChooseStartDateOld()
        {
            Logger.InitLogger();
            try
            {
                steps.SearchingCity(CITY);
                Assert.AreEqual(ERROR_DATE_TEXT, steps.GetNoStartDateStep());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        //Выбор даты отъезда из прошедшего времени или даты заезда
        [Test]
        public void ChooseEndDateOld()
        {
            Logger.InitLogger();
            try
            {
                steps.SearchingCityEnd(CITY);
                Assert.AreEqual(ERROR_DATE_TEXT_END, steps.GetNoEndDateStep());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
        // Выбор количества взрослых гостей меньше одного
        [Test]
        public void ChooseAmountOfPeopleLessThanOne()
        {
            Logger.InitLogger();
            try
            {
                steps.DeletingPeople();                
                Assert.AreEqual("1", steps.PositivValueAmountOfPerson());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
        
        // Выбор количества взрослых гостей больше 30
        [Test]
        public void ChooseAmountOfPeopleMoreThanThirty()
        {
            Logger.InitLogger();
            try
            {
                steps.AddingPeople();
                Assert.AreEqual("30", steps.PositivValueAmountOfPersonMax());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        // Выбор количества детей меньше нуля
        [Test]
        public void ChooseAmountOfChildrenLessThanZero()
        {
            Logger.InitLogger();
            try
            {
                steps.DeletingСhild();
                Assert.AreEqual("0", steps.ZeroChildren());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
        // Выбор количества детей больше 10
        [Test]
        public void ChooseAmountOfChildrenMoreThanTen()
        {
            Logger.InitLogger();
            try
            {
                steps.AddingChild();
                Assert.AreEqual("10", steps.MaxValueChildren());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        // Выбор количества комнат меньше 0
        [Test]
        public void ChooseAmountOfRoomsLessThanOne()
        {
            Logger.InitLogger();
            try
            {
                steps.DeletingRoom();
                Assert.AreEqual("1", steps.MinValueQuantityRooms());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
        // Выбор количества комнат больше 30
        [Test]
        public void ChooseAmountOfRoomsMoreThanThirty()
        {
            Logger.InitLogger();
            try
            {
                steps.AddingRoom();
                Assert.AreEqual("30", steps.MaxValueQuantityRooms());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
    }
}
