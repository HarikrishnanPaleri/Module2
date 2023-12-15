using BDDExam.Hooks;
using BDDExam.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace BDDExam.StepDefinitions
{
    [Binding]
    internal class SearchAddToCartStepDefinitions:CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;
        [Given(@"User will be on homepage")]
        public void GivenUserWillBeOnHomepage()
        {
            driver.Url = "https://magento.softwaretestingboard.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will type the '([^']*)'in the search box")]
        public void WhenUserWillTypeTheInTheSearchBox(string searchtext)
        {
            IWebElement? searchInput = driver?.FindElement(By.Id("search"));
            searchInput?.SendKeys(searchtext);
            searchInput?.SendKeys(Keys.Enter);
        }

        [Then(@"Search Results are loaded in the same page with '([^']*)'")]
        public void ThenSearchResultsAreLoadedInTheSamePageWith(string searchtext)
        {
            TakeScreenshot(driver);//screenshot taken
            try
            {
                Assert.That(driver.Url.Contains(searchtext));
                LogTestResult("Search Test", "Search Test Passed");//logfile
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }

        [When(@"User select the '([^']*)'")]
        public void WhenUserSelectThe(string pid)
        {
           
           driver.FindElement(By.XPath("(//div[@class='product-item-info'])[" + pid + "]")).Click();
            
        }
       

        [Then(@"Product page '([^']*)' is loaded")]
        public void ThenProductPageIsLoaded(string searchtext)
        {
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Title, Does.Contain(searchtext));
                LogTestResult("Search Test", "Search Test Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test", "Search Test Failed", ex.Message);
            }
        }

        [When(@"User Clicks the Add to Cart Button")]
        public void WhenUserClicksTheAddToCartButton()
        {
            driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
      

        }
        [Then(@"Product '([^']*)' added to cart")]
        public void ThenProductAddedToCart(string bag)
        {
            DefaultWait<IWebDriver> wait;

            wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval = TimeSpan.FromMilliseconds(300);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(d => ExpectedConditions.ElementToBeClickable(driver.FindElement(By.XPath("//a[text()='shopping cart']"))));
            driver.FindElement(By.XPath("//a[text()='shopping cart']")).Click();
            TakeScreenshot(driver);
            try
            {
                Assert.That(driver.Title, Does.Contain("Shopping Cart"));
                LogTestResult("Search and add to cart Test", "Search and add to cart Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search and add to cart", "Search and add to cart test -fail", ex.Message);
            }

        }


    }
}
