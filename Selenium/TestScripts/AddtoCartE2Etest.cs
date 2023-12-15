using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAssesment.PageObjects;
using SeleniumAssesment.Utililities;
using SeleniumExtras.WaitHelpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssesment.TestScripts
{
    [TestFixture]
    internal class AddtoCartE2Etest:CoreCodes
    {
        [Test]
        [TestCase("bag")]
        [Category("Regression testing")]
        public void AddToCartTest(string searchtext)
        {
            var homepage = new HomePage(driver);

            try
            { 

                var productlist = homepage.TypeSearch(searchtext);
                Log.Information("product entered");
                var productpage = productlist.ProductClick();
                Log.Information("product selected");
                productpage.AddToCartButtonClick();
                DefaultWait<IWebDriver> wait;
                wait = new DefaultWait<IWebDriver>(driver);
                wait.PollingInterval = TimeSpan.FromMilliseconds(300);
                wait.Timeout = TimeSpan.FromSeconds(20);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.Until(d => ExpectedConditions.ElementToBeClickable(productpage.CartButton));
                productpage.CartButtonClick();
                TakeScreenshot();
                Assert.That(driver.Title, Does.Contain("Shopping Cart"));
                LogTestResult("Add to cart Test", "TestPassed");
                test = extent.CreateTest("Add to cart test - Pass");
                test.Pass("Add to cart test passed");

            }
            catch (AssertionException ex)
            {
                LogTestResult("Add to cart test", "Add to wishlist test failed", ex.Message);
                test = extent.CreateTest("Add to cart test - Fail");
                test.Fail("Add to cart test failed");

            }

        }
    }

    }

