using SeleniumAssesment.PageObjects;
using SeleniumAssesment.Utililities;
using SeleniumAssesment.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssesment.TestScripts
{
    [TestFixture]
    internal class CreateAccountE2E:CoreCodes
    {
        [Test]
        public void CreateAccountTest()
        {
            var homepage = new HomePage(driver);
           

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "LUMA";
            List<SearchData> searchDataList = ExcelUtils.ReadSignUpData(excelFilePath, sheetName);
            try
            {
                foreach (var searchData in searchDataList)
                {
                    
                    string? FN = searchData?.FirstName;
                    string? LN = searchData?.LastName;
                    string? Email = searchData?.Email;
                    string? PWD = searchData?.Password;
                    string? ConPWD = searchData?.ConfirmPassword;
                    var createaccpage = homepage.CreateAccount();
                    Log.Information("Create account link clicked");
                    createaccpage.CreateAcc(FN, LN, Email, PWD, ConPWD);
                    Log.Information("Account created");
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("customer"));
                
                  
                    //Thread.Sleep(2000);
                    LogTestResult("CreateAccount Test", "TestPassed");
                    test = extent.CreateTest("Create Account test - Pass");
                    test.Pass("Create account test passed");
                }
            }
            catch (AssertionException ex)
            {
                LogTestResult("CreateAccount Test", "CreateAccount Test failed", ex.Message);
                test = extent.CreateTest("CreateAccount Test - Fail");
                test.Fail("CreateAccount Test failed");

            }
        }
    }
    }

