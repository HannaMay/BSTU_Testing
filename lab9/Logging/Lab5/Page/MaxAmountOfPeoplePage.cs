using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    class MaxAmountOfPeoplePage:AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".xp__input-group.xp__guests")]
        private IWebElement peopleBox;


        [FindsBy(How = How.CssSelector, Using = ".bui-button.bui-button--secondary.bui-stepper__add-button")]
        private IWebElement personPlus;

        [FindsBy(How = How.XPath, Using = "//*[@id='xp__guests__inputs-container']/..//div[2]/span[1]")]
        private IWebElement adultsValue;

        public MaxAmountOfPeoplePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public MaxAmountOfPeoplePage GetStatiscBox()
        {
            peopleBox.Click();
            return new MaxAmountOfPeoplePage(driver);
        }

        public MaxAmountOfPeoplePage AddPeople()
        {
            personPlus.Click();
            return new MaxAmountOfPeoplePage(driver);
        }

        public string PositivValueAmountOfPerson()
        {
            return adultsValue.Text.ToString();
        }
    }
}
