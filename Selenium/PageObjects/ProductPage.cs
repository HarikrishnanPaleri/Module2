using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAssesment.Utililities;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssesment.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//span[text()='Add to Wish List']")]
        public IWebElement? AddToWishlistButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[2]")]
        public IWebElement? AddtoCartButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='shopping cart']")]
        public IWebElement? CartButton { get; set; }

        



        public void AddToCartWishlistClick()
        {
            var fluentwait = CoreCodes.Wait(driver);
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(AddToWishlistButton));
            AddToWishlistButton?.Click();
            
           
        }

        public void AddToCartButtonClick()
        {
            var fluentwait = CoreCodes.Wait(driver);
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(AddtoCartButton));
            AddtoCartButton?.Click();
            


        }

        public void CartButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(CartButton));
            
            CartButton?.Click();
           
       
         

        }




    }


}

