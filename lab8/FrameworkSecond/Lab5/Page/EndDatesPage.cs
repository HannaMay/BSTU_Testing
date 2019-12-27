using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    public class EndDatesPage : AbstractPage
    {
        private const string BASE_URL = "https://www.booking.com";
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "ss")]
        private IWebElement searchField;

        [FindsBy(How = How.CssSelector, Using = ".sb-searchbox__button")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.CssSelector, Using = ".xp__dates-inner")]
        private IWebElement calendar;


        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/..//tr[5]/td[6]")]
        private IWebElement calendarStart;

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/..//tr[5]/td[5]")]
        private IWebElement calendarEnd;

        [FindsBy(How = How.CssSelector, Using = ".bui-calendar__display")]
        private IWebElement calendarDisplay;
               
        public EndDatesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Dates Page opened");
        }

        public EndDatesPage SearchingCity(string city)
        {
            searchField.SendKeys(city);
            return new EndDatesPage(driver);
        }

        public EndDatesPage TakeCalendar()
        {
            calendar.Click();
            calendarStart.Click();
            calendarEnd.Click();
            return new EndDatesPage(driver);

        }

        public string GetNoEndDate()
        {
            var date = calendarDisplay.Text;
            return calendarDisplay.Text.ToString();
        }
    }
}
