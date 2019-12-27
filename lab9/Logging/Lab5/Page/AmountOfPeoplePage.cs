using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    class AmountOfPeoplePage :AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".xp__input-group.xp__guests")]
        private IWebElement peopleBox;

        [FindsBy(How = How.CssSelector, Using = ".bui-button.bui-button--secondary.bui-stepper__subtract-button")]
        private IWebElement personMinus;

        [FindsBy(How = How.XPath, Using = "//*[@id='xp__guests__inputs-container']/..//div[2]/span[1]")]
        private IWebElement adultsValue;

        public AmountOfPeoplePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public AmountOfPeoplePage GetStatiscBox()
        {
            peopleBox.Click();
            return new AmountOfPeoplePage(driver);
        }

        public AmountOfPeoplePage DeletePeople()
        {
            personMinus.Click();
            return new AmountOfPeoplePage(driver);
        }

        public string PositivValueAmountOfPerson ()
        {
            return adultsValue.Text.ToString();
        }


    }
}
