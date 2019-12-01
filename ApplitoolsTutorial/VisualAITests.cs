using Applitools;
using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;


namespace ApplitoolsTutorial
{

    [TestFixture]
    public class VisualAITests
    {
        private EyesRunner runner;
        private Eyes eyes;

        BatchInfo  b = new BatchInfo("Hackathon");
        private IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
           
            //Initialize the Runner for your test.
            runner = new ClassicRunner();
            eyes.ApiKey = "sAJ100IdivMW4Z3lIe5uX4T1X1aX7La111u4rWan6104RlVSI110";
             eyes.Batch = b;
            // Initialize the eyes SDK (IMPORTANT: make sure your API key is set in the APPLITOOLS_API_KEY env variable).
            eyes = new Eyes(runner);
        
            // Use Chrome browser
            driver = new ChromeDriver();
        }


        [Test]
        public void BasicTest()
        {
            eyes.Batch = b;
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            eyes.Open(driver, "Login page", "UI Verification", new Size(800, 600));

            // Navigate the browser 
            driver.Url = "https://demo.applitools.com/hackathon.html";
         //   driver.Url = "https://demo.applitools.com/hackathonV2.html";

            // Visual checkpoint #1 - Check the login page.
            eyes.CheckWindow("Login Page");

            // This will create a test with two test steps.
            driver.FindElement(By.Id("log-in")).Click();
            
            // Visual checkpoint #2 - Check the app page.
            eyes.CheckWindow("App Window");

            // End the test.
            eyes.CloseAsync();
        }

        // empty credentials
        [Test]
        public void LoginWithEmptyCredentials()
        {
            //Open browser
            driver.Url ="https://demo.applitools.com/hackathon.html";

            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Start the test
            eyes.Open(driver, "Login App", "Login Page Test Test", new Size(800, 600));

            // Take a screenshot
            eyes.CheckWindow("Login Window");

            //End the test
            eyes.CloseAsync();

        }

        // only enter the username and click the login button

        [Test]
        public void LoginWithEmptyPassword()
        {
            //Open browser
            driver.Url = "https://demo.applitools.com/hackathon.html";

            //Enter username
            driver.FindElement(By.Id("username")).SendKeys("Mal");
            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Start the test
            eyes.Open(driver, "Login App", "Login Page empty Password Error Test", new Size(800, 600));

            // Take a screenshot
            eyes.CheckWindow("Login Window");

            //End the test
            eyes.CloseAsync();

        }

        // only enter the password and click the login button

        [Test]
        public void LoginWithEmptyUsername()
        {
            //Open browser
            driver.Url = "https://demo.applitools.com/hackathon.html";

            //Enter password
            driver.FindElement(By.Id("password")).SendKeys("abc");
            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Start the test
            eyes.Open(driver, "Login App", "Login Page empty Username Error Test", new Size(800, 600));

            // Take a screenshot
            eyes.CheckWindow("Login Window");

            //End the test
            eyes.CloseAsync();

        }

        // enter both username  and password verify Home page
        [Test]
        public void Successful_login()
        {
            //Open browser
            driver.Url = "https://demo.applitools.com/hackathon.html";

            //Enter username
            driver.FindElement(By.Id("username")).SendKeys("Mal");
            //Enter password
            driver.FindElement(By.Id("password")).SendKeys("abc");
            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Start the test
            eyes.Open(driver, "Login App", "Verify Successful Login", new Size(800, 600));

            // Take a screenshot
            eyes.CheckWindow("Login Window");

            //End the test
            eyes.CloseAsync();

        }

        // VerifyTable
        [Test]
        public void Verifytable()
        {
            //Open browser
            driver.Url = "https://demo.applitools.com/hackathon.html";

            //Enter username
            driver.FindElement(By.Id("username")).SendKeys("Mal");
            //Enter password
            driver.FindElement(By.Id("password")).SendKeys("abc");
            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Click table header
            driver.FindElement(By.Id("amount")).Click();

            //Start the test
            eyes.Open(driver, "Table Sort", "Amount column sort Test", new Size(800, 600));

            // Take a screenshot
            eyes.CheckWindow("Window with Table");


            //End the test
            eyes.CloseAsync();

        }

        // Verify Expenses Chart
        [Test]
        public void VerifyChart()
        {
            //Open browser
            driver.Url = "https://demo.applitools.com/hackathon.html";

            //Enter username
            driver.FindElement(By.Id("username")).SendKeys("Mal");
            //Enter password
            driver.FindElement(By.Id("password")).SendKeys("abc");
            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Click Compare Expenses
            driver.FindElement(By.Id("showExpensesChart")).Click();

            //Click show data for next year
            driver.FindElement(By.ClassName("btn btn-warning")).Click();

            //Start the test
            eyes.Open(driver, "Expense Chart", "Verify Expenses Chart", new Size(800, 600));

            // Take a screenshot
            eyes.CheckWindow("Expenses");


            //End the test
            eyes.CloseAsync();

        }


        // Verify Dyanamic Page 
        

        public void VerifydyanamicPage()
        {
            //Open browser
            driver.Url = "https://demo.applitools.com/hackathon.html?showAd=true";

            //Enter username
            driver.FindElement(By.Id("username")).SendKeys("Mal");
            //Enter password
            driver.FindElement(By.Id("password")).SendKeys("abc");
            // Click on login btn
            driver.FindElement(By.Id("log-in")).Click();

            //Start the test
            eyes.Open(driver, "FlashSaleGif", "Verify Gif Flash Sale Image", new Size(800, 600));

            //Checkimage region
            eyes.CheckRegion(By.ClassName("element - balances"), "Flash Sale Images");
            // Take a screenshot
            eyes.CheckWindow("TestFlashImages");

            //End the test
            eyes.CloseAsync();

        }

        [TearDown]
        public void AfterEach()
        {
            // Close the browser.
            driver.Quit();

            // If the test was aborted before eyes.close was called, ends the test as aborted.
            eyes.AbortIfNotClosed();

            //Wait and collect all test results
            TestResultsSummary allTestResults = runner.GetAllTestResults();
        }

    }
}
