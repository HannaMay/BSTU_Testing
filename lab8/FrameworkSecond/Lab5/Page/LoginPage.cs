using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;

namespace Lab5.Page
{
    public class LoginPage : AbstractPage
    {
        private const string BASE_URL = "https://account.booking.com/sign-in";

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//span[text()='Next']")]
        private IWebElement buttonNext;

        [FindsBy(How = How.XPath, Using = "//span[text()='Sign in']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.CssSelector, Using = ".header_name.user_firstname.ge-no-yellow-bg")]
        private IWebElement personLink;

        [FindsBy(How = How.CssSelector, Using = ".profile-menu__item.profile_menu__item--mysettings")]
        private IWebElement linkSettings;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement userEmail;

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            inputLogin.SendKeys(username);
            buttonNext.Click();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            //Task.Delay(6000);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
            personLink.Click();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            linkSettings.Click();
        }
        
        public string GetLoggedInUserName()
        {
            return userEmail.GetAttribute("data-email");
        }
    }
}
