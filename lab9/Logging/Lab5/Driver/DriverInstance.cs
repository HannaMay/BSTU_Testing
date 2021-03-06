﻿using System;
using OpenQA.Selenium;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using Lab5.Utils;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Lab5.Driver
{
    public class DriverInstance
    {
        
        private static IWebDriver driver;
        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {

            if (driver != null) return driver;

            var configuration = ConfigurationService.GetIConfigurationRoot();
            switch (configuration["Browser"])
            {
                case "chrome":
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    }

                default:
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    }
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

        public static void CloseBrowser()
        {            
            driver.Quit();
            driver = null;
        }
    }
}
