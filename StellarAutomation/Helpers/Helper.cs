using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;

namespace StellarAutomation.Helpers
{

    public static class Helper
    {
        private static readonly IWebDriver _driver = new ChromeDriver();

        

        public static bool IsElementVisible(By locator)
        {
            var isVisible = false;
            try
            {
                isVisible = WaitForElementUntilIsVisible(locator).Displayed;
            }
            catch (NoSuchElementException e)
            {
                isVisible = false;
            }
            catch (Exception e)
            {
                isVisible = false;
            }
            return isVisible;
        }

        public static IWebElement WaitForElementUntilIsVisible(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        public static IWebElement WaitForElementUntilIsClickable(By locator, int seconds = 10)
        {
            var wait = new WebDriverWait(_driver, System.TimeSpan.FromSeconds(seconds));

            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

            return element;
        }

        public static void WaitMilliSeconds(int milliseconds)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(milliseconds));
        }

        public static void ScrollToElement(By locator)
        {

            var element = _driver.FindElement(locator);
            Actions actions = new Actions(_driver);
            try
            {
                actions.MoveToElement(element).Perform();
            }
            catch (MoveTargetOutOfBoundsException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            WaitMilliSeconds(130);


        }

        public static void Scroll(By locator)
        {
            _driver.FindElement(locator).SendKeys(Keys.ArrowDown);
        }

        public static void OpenPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
        }

        public static void ClickElement(By locator)
        {
            
            WaitForElementUntilIsClickable(locator);

            ScrollToElement(locator);

            _driver.FindElement(locator).Click();
        }

        public static void ClearFieldAndSentKeys(By locator, string text)
        {
            WaitForElementUntilIsVisible(locator);

            ClickElement(locator);

            _driver.FindElement(locator).SendKeys(Keys.Delete);

            _driver.FindElement(locator).SendKeys(text);

        }

        public static string GetElementText(By locator)
        {
            string value = _driver.FindElement(locator).Text;

            return value;
        }

        public static void SwitchToAWindow(int windowNumber)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[windowNumber]);
        }

        public static void DisposeSession()
        {
            _driver.Dispose();
        }


    }
}