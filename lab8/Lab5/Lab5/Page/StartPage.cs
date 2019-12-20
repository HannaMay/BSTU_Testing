using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;

namespace Lab5.Page
{
    public class StartPage : AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";

        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "ss")]
        private IWebElement searchField;

        [FindsBy(How = How.CssSelector, Using = ".sb-searchbox__button")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.CssSelector, Using = ".sb-searchbox__error.-visible")]
        private IWebElement errorMessage;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Page opened");            
        }

        public void Searching(string city)
        {
            searchField.SendKeys(city);
            buttonSearch.Click();
        }

        public string ErrorMessageSearch()
        {
            return errorMessage.Text.ToString();
        }
    }
}
