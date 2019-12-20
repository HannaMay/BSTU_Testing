using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject.Page
{
    class MainPage
    {
        [FindsBy(How = How.Name, Using = "ss")]
        private IWebElement Search;

        public MainPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public MainPage InputSearch(string q)
        {
            Search.SendKeys(q);
            Search.SendKeys(Keys.Enter);
            Task.Delay(12000);
            return this;
        }



        [FindsBy(How = How.XPath, Using = @"//*[@id='filter_price']/div[2]/a[1]")] //изменить x-path До ближайшего класса
        private IWebElement inputFilter;
        public MainPage InputFilter()
        {
            inputFilter.FindElement(By.XPath("//*[@id='filter_price']/div[2]/a[1]"));
            Console.WriteLine("tut");
            inputFilter.Click();
            Console.WriteLine("tut1");
            return this;
        }
    }
}
