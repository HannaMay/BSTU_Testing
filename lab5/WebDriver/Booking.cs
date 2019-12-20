using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Lab5
{
    class Booking
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void PriceTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.booking.com");
            IWebElement searchInput = driver.FindElement(By.Id("ss"));
            searchInput.SendKeys("Milan" + OpenQA.Selenium.Keys.Enter);

            Task.Delay(12000);
            IWebElement calendarInputStart = driver.FindElement(By.ClassName("c2-day-s-today"));
            calendarInputStart.Click();

            IWebElement searchBtn = driver.FindElement(By.ClassName("sb-searchbox__button"));
            searchBtn.Click();

            IWebElement priceHotel = driver.FindElement(By.ClassName("bui-price-display__value"));
            Console.WriteLine(priceHotel.Text);

            Task.Delay(7000);
            IWebElement hotelSelected = driver.FindElement(By.ClassName("sr-cta-button-row"));
            hotelSelected.Click();

            IWebElement priceHotelDetail = driver.FindElement(By.ClassName("bui-price-display__value"));
            Console.WriteLine(priceHotelDetail.Text);

            if (priceHotel.Text == priceHotelDetail.Text)
            {
                Console.WriteLine("Test passed successfully, price hotel = price detail hotel");                
            }
            else
            {
                Console.WriteLine("Test failed");                
            }  
        }

        [Test]
        public void CalendarTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.booking.com");
            IWebElement searchInput = driver.FindElement(By.Id("ss"));
            searchInput.SendKeys("Kioto" + OpenQA.Selenium.Keys.Enter);

            Task.Delay(12000);
            IWebElement calendarInputStart = driver.FindElement(By.ClassName("c2-day-s-disabled"));
            calendarInputStart.Click();

            if (calendarInputStart.Enabled)
            {
                Console.WriteLine("Element is disable to click");
            }
            else
            {
                Console.WriteLine("Element is enable to click");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }
}
