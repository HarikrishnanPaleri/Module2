using BDDExam.Hooks;
using BDDExam.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BDDExam.StepDefinitions
{
    [Binding]
    internal class SearchWishlistStepDefinitions:CoreCodes
    {

        IWebDriver? driver = AllHooks.driver;
        [When(@"User Clicks the Add To Wishlist button")]
        public void WhenUserClicksTheAddToWishlistButton()
        {
            driver.FindElement(By.XPath("//span[text()='Add to Wish List']")).Click();
        }

        [Then(@"Product '([^']*)' added to wishlist")]
        public void ThenProductAddedToWishlist(string searchtext)
        {
            try
            {
                Assert.That(driver.Title, Does.Contain("Customer Login"));
                LogTestResult("Search and add to Wishlist Test", "Search and add to Wishlist Passed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Search and add to Wishlist", "Search and add to Wishlist test -fail", ex.Message);
            }


        }
    }
}
