using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    class MaxValueRoomsPage:AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".xp__input-group.xp__guests")]
        private IWebElement peopleBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='xp__guests__inputs-container']/..//div[3]/div/div[2]/button[2]")]
        private IWebElement roomPlus;

        [FindsBy(How = How.XPath, Using = "//*[@id='xp__guests__inputs-container']/..//div[3]/div/div[2]/span[1]")]
        private IWebElement roomsValue;

        public MaxValueRoomsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public MaxValueRoomsPage GetStatiscBox()
        {
            peopleBox.Click();
            return new MaxValueRoomsPage(driver);
        }

        public MaxValueRoomsPage AddRoom()
        {
            roomPlus.Click();
            return new MaxValueRoomsPage(driver);
        }

        public string GetMaxValueRooms()
        {
            return roomsValue.Text.ToString();
        }
    }
}
