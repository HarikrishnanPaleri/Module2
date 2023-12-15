using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssesment.PageObjects
{
    internal class ProductListPage
    {
        IWebDriver driver;
        public ProductListPage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "(//div[@class='product-item-info'])[2]")]
        public IWebElement? Product { get; set; }

        public ProductPage ProductClick()
        {
            Product?.Click();
            return new ProductPage(driver);
        }

    }
}


