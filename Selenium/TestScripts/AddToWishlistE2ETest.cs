using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumAssesment.PageObjects;
using SeleniumAssesment.Utililities;
using SeleniumAssesment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using Serilog;

namespace SeleniumAssesment.TestScripts
{
    [TestFixture]
    internal class AddToWishlistE2ETest:CoreCodes
    {
        [Test]
        [Category("Regression testing")]
        [TestCase("bag")]
        public void AddtoWishlisttest(string searchtext)
        {
            var homepage = new HomePage(driver);
           
           try
          {
               
                var productlist =  homepage.TypeSearch(searchtext);
                Log.Information("product entered");
                var productpage = productlist.ProductClick();
                Log.Information("product selected");
                productpage.AddToCartWishlistClick();
                Log.Information("product added to wish list");
                TakeScreenshot();
                Assert.That(driver.FindElement(By.XPath("//h1[@class='page-title']")).Text.Contains("Customer Login"));
                LogTestResult("Add to wishlist Test", "TestPassed");
                test = extent.CreateTest("Add to wishlist test - Pass");
                test.Pass("Add to wishlist test passed");

            }
            catch (AssertionException ex)
            {
                LogTestResult("Add to wishlist test", "Add to wishlist test failed", ex.Message);
                test = extent.CreateTest("Add to wishlist test - Fail");
                test.Fail("Add to wishlist test failed");

            }
         
        }
    }
}
