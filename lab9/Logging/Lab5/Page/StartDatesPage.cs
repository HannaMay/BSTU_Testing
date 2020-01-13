using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Page
{
    public class StartDatesPage: AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "ss")]
        private IWebElement searchField;

        [FindsBy(How = How.CssSelector, Using = ".sb-searchbox__button")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.CssSelector, Using = ".xp__dates-inner")]
        private IWebElement calendar;


        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/..//tr[2]/td[1]")]
        private IWebElement calendarStart;

        [FindsBy(How = How.CssSelector, Using = ".bui-calendar__display")]
        private IWebElement calendarDisplay;
       


        public StartDatesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public StartDatesPage SearchingCity(string city)
        {
            searchField.SendKeys(city);
            return new StartDatesPage(driver);
        }

        public StartDatesPage TakeCalendar()
        {
            calendar.Click();
            calendarStart.Click();
            return new StartDatesPage(driver);

        }

        public string GetNoStartDate()
        {
            var date = calendarDisplay.Text;
            return calendarDisplay.Text.ToString();
        }

    }
}
