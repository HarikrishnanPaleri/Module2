using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssesment.PageObjects
{
   
    internal class CreateAccountPage
    {   IWebDriver driver;
        public CreateAccountPage(IWebDriver? driver)
        {

            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement? FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement? LastName { get; set; }

        [FindsBy(How = How.Id, Using = "email_address")]
        public IWebElement? Email { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement? Password { get; set; }

        [FindsBy(How = How.Id, Using = "password-confirmation")]
        public IWebElement? ConfirmPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[text()='Create an Account'])[1]")]
        public IWebElement? CreatAccountButton { get; set; }

        public void CreateAcc(string fname, string lname, string email,string pwd,string conpwd)
        {
            FirstName?.SendKeys(fname);
            LastName?.SendKeys(lname);
            Email?.SendKeys(email);
            Password?.SendKeys(pwd);
            ConfirmPassword?.SendKeys(conpwd);
            CreatAccountButton?.Click();
  
        }

    }
}
