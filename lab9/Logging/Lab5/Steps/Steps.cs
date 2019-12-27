using System;
using OpenQA.Selenium;

namespace Lab5.Steps
{
    public class Steps
    {
        public IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginBooking(string username, string password)
        {
            Page.LoginPage loginPage = new Page.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public string GetLoggedInUserName()
        {
            Page.LoginPage loginPage = new Page.LoginPage(driver);
            return loginPage.GetLoggedInUserName();
        }
        
        public void SearchingError(string incorrect_city)
        {
            Page.StartPage startPage = new Page.StartPage(driver);
            startPage.OpenPage();
            startPage.Searching(incorrect_city);
        }

        public string SearchIncorrectCity()
        {
            Page.StartPage startPage = new Page.StartPage(driver);
            return startPage.ErrorMessageSearch();
        }

        public void SearchingCity(string city)
        {
            Page.StartDatesPage startPageDate = new Page.StartDatesPage(driver);            
            startPageDate.OpenPage();
            startPageDate.SearchingCity(city).TakeCalendar().GetNoStartDate();
        }

        public string GetNoStartDateStep()
        {
            Page.StartDatesPage startPageDate = new Page.StartDatesPage(driver);
            return startPageDate.GetNoStartDate();
        }

        public void SearchingCityEnd(string city)
        {
            Page.EndDatesPage endPageDate = new Page.EndDatesPage(driver);
            endPageDate.OpenPage();
            endPageDate.SearchingCity(city).TakeCalendar().GetNoEndDate();
        }

        public string GetNoEndDateStep()
        {
            Page.EndDatesPage startPageDate = new Page.EndDatesPage(driver);
            return startPageDate.GetNoEndDate();
        }


        public void DeletingPeople()
        {
            Page.AmountOfPeoplePage amountOfPeoplePage = new Page.AmountOfPeoplePage(driver);
            amountOfPeoplePage.OpenPage();
            amountOfPeoplePage.GetStatiscBox();
            for (int i = 1; i <= 2; i++)
                amountOfPeoplePage.DeletePeople();
        }

        public string PositivValueAmountOfPerson()
        {
            Page.AmountOfPeoplePage amountOfPeoplePage = new Page.AmountOfPeoplePage(driver);
            return amountOfPeoplePage.PositivValueAmountOfPerson();
        }

        public void AddingPeople()
        {
            Page.MaxAmountOfPeoplePage maxAmountOfPeoplePage = new Page.MaxAmountOfPeoplePage(driver);
            maxAmountOfPeoplePage.OpenPage();
            maxAmountOfPeoplePage.GetStatiscBox();
            for (int i = 1; i <= 31; i++)            
                maxAmountOfPeoplePage.AddPeople();            
        }

        public string PositivValueAmountOfPersonMax()
        {
            Page.MaxAmountOfPeoplePage maxAmountOfPeoplePage = new Page.MaxAmountOfPeoplePage(driver);
            return maxAmountOfPeoplePage.PositivValueAmountOfPerson();
        }
               
        public void DeletingСhild()
        {
            Page.ZeroAmountOfPeoplePage zeroAmountOfPeoplePage = new Page.ZeroAmountOfPeoplePage(driver);
            zeroAmountOfPeoplePage.OpenPage();
            zeroAmountOfPeoplePage.GetStatiscBox();
            for (int i = 1; i <= 1; i++)
                zeroAmountOfPeoplePage.DeleteChild();
        }

        public string ZeroChildren()
        {
            Page.ZeroAmountOfPeoplePage zeroAmountOfPeoplePage = new Page.ZeroAmountOfPeoplePage(driver);
            return zeroAmountOfPeoplePage.PositivValueAmountOfChildren();
        }

        public void AddingChild()
        {
            Page.MaxAmountOfChildrenPage maxAmountOfChildrenPage = new Page.MaxAmountOfChildrenPage(driver);
            maxAmountOfChildrenPage.OpenPage();
            maxAmountOfChildrenPage.GetStatiscBox();
            for (int i = 1; i <= 10; i++)
                maxAmountOfChildrenPage.AddChild();
        }

        public string MaxValueChildren()
        {
            Page.MaxAmountOfChildrenPage maxAmountOfChildrenPage = new Page.MaxAmountOfChildrenPage(driver);
            return maxAmountOfChildrenPage.PositivValueAmountOfChildren();
        }
                          
        public void DeletingRoom()
        {
            Page.MinValueRoomsPage minValueRoomsPage = new Page.MinValueRoomsPage(driver);
            minValueRoomsPage.OpenPage();
            minValueRoomsPage.GetStatiscBox();
            for (int i = 1; i <= 1; i++)
                minValueRoomsPage.DeleteRoom();
        }

        public string MinValueQuantityRooms()
        {
            Page.MinValueRoomsPage minValueRoomsPage = new Page.MinValueRoomsPage(driver);
            return minValueRoomsPage.GetMinValueRooms();
        }

        public void AddingRoom()
        {
            Page.MaxValueRoomsPage maxValueRoomsPage = new Page.MaxValueRoomsPage(driver);
            maxValueRoomsPage.OpenPage();
            maxValueRoomsPage.GetStatiscBox();
            for (int i = 1; i <= 31; i++)
                maxValueRoomsPage.AddRoom();
        }

        public string MaxValueQuantityRooms()
        {
            Page.MaxValueRoomsPage maxValueRoomsPage = new Page.MaxValueRoomsPage(driver);
            return maxValueRoomsPage.GetMaxValueRooms();
        }
    }
}
