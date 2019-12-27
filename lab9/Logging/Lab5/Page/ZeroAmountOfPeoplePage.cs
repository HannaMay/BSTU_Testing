using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    class ZeroAmountOfPeoplePage:AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".xp__input-group.xp__guests")]
        private IWebElement peopleBox;


        [FindsBy(How = How.XPath, Using = "//*[@id='xp__guests__inputs-container']/..//div[2]/div/div[2]/button[1]")]
        private IWebElement childMinus;

        [FindsBy(How = How.XPath, Using = "//*[@id='xp__guests__inputs-container']/..//div[2]/div/div[2]/span[1]")]
        private IWebElement childrenValue;

        public ZeroAmountOfPeoplePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public ZeroAmountOfPeoplePage GetStatiscBox()
        {
            peopleBox.Click();
            return new ZeroAmountOfPeoplePage(driver);
        }

        public ZeroAmountOfPeoplePage DeleteChild()
        {
            childMinus.Click();
            return new ZeroAmountOfPeoplePage(driver);
        }

        public string PositivValueAmountOfChildren()
        {
            return childrenValue.Text.ToString();
        }
    }
}
