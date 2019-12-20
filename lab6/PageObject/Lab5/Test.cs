//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PageObject.Page;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.PageObjects;

//namespace PageObject
//{
//    public class Testing
//    {
//        IWebDriver driver;
//        private static string HomePage = "https://www.booking.com";

//        [Test]
//        public void PriceTest()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl(HomePage);

//            MainPage priceHotelPage = new MainPage(driver)
//                .InputSearch("Milan");
//            MainPage priceHotelPage2 = new MainPage(driver).InputFilterDetails("c2-day-s-today");

//            MainPage hotelSelected = new MainPage(driver)
//                .InputFilterDetails("sr-cta-button-row")
//                .GetElement("bui-price-display__value");

//            if (priceHotelPage.ToString() == hotelSelected.ToString())
//            {
//                Console.WriteLine("Test passed successfully, price hotel = price detail hotel");
//            }
//            else
//            {
//                Console.WriteLine("Test failed");
//            }


//            driver.Close();
//        }

//        [Test]
//        public void CalendarTest()
//        {
//            driver = new ChromeDriver();
//            driver.Navigate().GoToUrl(HomePage);

//            MainPage calendarInputPage = new MainPage(driver)
//                .InputSearchText("Kioto");

//            IWebElement calendarInputStart = driver.FindElement(By.ClassName("c2-day-s-disabled"));
//            calendarInputStart.Click();

//            if (calendarInputStart.Enabled)
//            {
//                Console.WriteLine("Element is disable to click");
//            }
//            else
//            {
//                Console.WriteLine("Element is enable to click");
//            }

//            driver.Close();
//        }
//    }
//}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageObject.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework.Internal;

namespace PageObject
{
    [TestClass]
    public class Test
    {
        IWebDriver Browser;
        private static string HomePage = "https://www.booking.com";
        private static string MilanPage = "https://www.booking.com/searchresults.en-gb.html?label=gen173nr-1DCAEoggI46AdIM1gEaCWIAQGYAQm4ARfIAQzYAQPoAQGIAgGoAgO4As-jx-8FwAIB&lang=en-gb&sid=8bffb288c7dfbb4107e239d38832dc19&sb=1&src=index&src_elem=sb&error_url=https%3A%2F%2Fwww.booking.com%2Findex.en-gb.html%3Flabel%3Dgen173nr-1DCAEoggI46AdIM1gEaCWIAQGYAQm4ARfIAQzYAQPoAQGIAgGoAgO4As-jx-8FwAIB%3Bsid%3D8bffb288c7dfbb4107e239d38832dc19%3Bsb_price_type%3Dtotal%26%3B&ss=Milan&is_ski_area=0&ssne=Milan&ssne_untouched=Milan&dest_id=-121726&dest_type=city&checkin_year=2019&checkin_month=12&checkin_monthday=12&checkout_year=2019&checkout_month=12&checkout_monthday=13&group_adults=2&group_children=0&no_rooms=1&b_h4u_keep_filters=&from_sf=1";

        [TestMethod]
        public void TestSearch()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl(HomePage);

            MainPage priceHotelPage = new MainPage(Browser).InputSearch("Miltgdfdhan");

            Browser.Quit();
        }
        
        [TestMethod]
        public void TestFilter()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl(MilanPage);

            MainPage orderHotelPage = new MainPage(Browser)            
                .InputFilter();

            Browser.Quit();
        }      

    }
}
