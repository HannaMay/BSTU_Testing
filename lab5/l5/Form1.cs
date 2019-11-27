using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace l5
{
    public partial class Form1 : Form
    {
        IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.booking.com");

            IWebElement searchInput = driver.FindElement(By.Id("ss"));
            searchInput.SendKeys("Милан" + OpenQA.Selenium.Keys.Enter);           

            Task.Delay(10000);
            IWebElement calendarInputStart = driver.FindElement(By.ClassName("c2-day-s-today"));
            calendarInputStart.Click();

            IWebElement searchBtn = driver.FindElement(By.ClassName("sb-searchbox__button"));
            searchBtn.Click();

            IWebElement priceHotel = driver.FindElement(By.ClassName("bui-price-display__value"));
            Console.WriteLine(priceHotel.Text);

            IWebElement hotelSelected = driver.FindElement(By.ClassName("sr-cta-button-row"));
            hotelSelected.Click();

            IWebElement priceHotelDetail = driver.FindElement(By.ClassName("bui-price-display__value"));
            Console.WriteLine(priceHotelDetail.Text);

            if (priceHotel.Text == priceHotelDetail.Text)
            {
                Console.WriteLine("Test passed successfully");
            } else
            {
                Console.WriteLine("Test failed");
            }
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            driver.Close();
        }
    }
}
