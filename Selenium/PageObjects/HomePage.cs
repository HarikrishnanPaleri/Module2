using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssesment.PageObjects
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement? SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//a[text()='Create an Account'])[1]")]
        public IWebElement? Createlink { get; set; }

       


        public ProductListPage TypeSearch(string searchTerm)
        {
            SearchBox?.SendKeys(searchTerm);
            SearchBox?.SendKeys(Keys.Enter);
            return new ProductListPage(driver);
        }
        public CreateAccountPage CreateAccount()
        {

            Createlink.Click();
            return new CreateAccountPage(driver);
        }
    }
}
