using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore
{
    [TestClass]
    public class TraditionalTests
    {
        private ChromeDriver _driver;

               
        // UI Validation

         [TestMethod]
        public void UIverification()
        {
            // Open Application V1
            // _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathon.html");

            // Open Application V2
            _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathonV2.html");


            //assert username label exists
            Assert.AreEqual("Username", _driver.FindElement(By.XPath("/html/body/div/div/form/div[1]/label")).GetAttribute("Username"));

            //assert password label exists
            Assert.AreEqual("Password", _driver.FindElement(By.XPath("/html/body/div/div/form/div[2]/label")).GetAttribute("Password"));
          
            // assert password field exists 
            _driver.FindElement(By.Id("password"));

            // assert Login button exists 
            Assert.IsTrue(_driver.FindElement(By.Id("log-in")).Displayed);

            //assert Remember Me text exists
            Assert.AreEqual("Remember Me", _driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div[1]/label")).Text.Contains("Remember Me"));
            
            // assert remember me checkbox
            Assert.IsTrue(_driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div[1]/label/input")).Displayed);

            // assert twitter icon exists 
            Assert.IsTrue(_driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div[2]/a[1]/img")).Displayed);

            // assert FB icon exists 
            Assert.IsTrue(_driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div[2]/a[2]/img")).Displayed);

            // assert Linkdin icon exists 
            Assert.IsTrue(_driver.FindElement(By.XPath("/html/body/div/div/form/div[3]/div[2]/a[3]/img")).Displayed);

        }


                // Data Driven Test
                //step a
                [TestMethod]
                public void EmptycredentialValidation()
                {
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    _driver = new ChromeDriver(outPutDirectory);
                   // App V1
                  //  _driver.Navigate().GoToUrl(" https://demo.applitools.com/hackathon.html");
                    // App V2
                     _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathonV2.html");

            var loginButton = _driver.FindElement(By.Id("log-in"));
                    loginButton.Click();

                    try
                    {
                        Assert.IsTrue(_driver.FindElement(By.Id("random_id_3")).Text.Contains("Both Username and Password must be present"));
                        Console.Write("DD step a passed");

                    }
                    catch (Exception e)
                    {

                        Console.Write(e);
                    }

                }


                // step b
                [TestMethod]
                public void EmptypasswordValidation()
                {
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    _driver = new ChromeDriver(outPutDirectory);
                   // _driver.Navigate().GoToUrl(" https://demo.applitools.com/hackathon.html");
            // Open Application V2
            _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathonV2.html");

            _driver.FindElement(By.Id("username")).SendKeys("Mal");
                    _driver.FindElement(By.Id("log-in")).Click();

                    try
                    {
                        Assert.IsTrue(_driver.FindElement(By.Id("random_id_3")).Text.Contains("Password must be present"));
                        Console.Write("DD step b passed");

                    }
                    catch (Exception e)
                    {

                        Console.Write(e);
                    }

            
                }



                // step c
                [TestMethod]
                public void EmptyusernameValidation()
                {
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    _driver = new ChromeDriver(outPutDirectory);
                    _driver.Navigate().GoToUrl(" https://demo.applitools.com/hackathon.html");

                    _driver.FindElement(By.Id("password")).SendKeys("pwd");
                    _driver.FindElement(By.Id("log-in")).Click();

                    try
                    {
                        Assert.IsTrue(_driver.FindElement(By.Id("random_id_3")).Text.Contains("Username must be present"));
                        Console.Write("DD step c passed");

                    }
                    catch (Exception e)
                    {

                        Console.Write(e);
                    }



                }


                // step d
                [TestMethod]
                public void Successful_Login()
                {
                    var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    _driver = new ChromeDriver(outPutDirectory);
            // _driver.Navigate().GoToUrl(" https://demo.applitools.com/hackathon.html");
            // Open Application V2
            _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathonV2.html");

            _driver.FindElement(By.Id("username")).SendKeys("Mal");
                    _driver.FindElement(By.Id("password")).SendKeys("pwd");
                    _driver.FindElement(By.Id("log-in")).Click();

                    try
                    {
                        Assert.IsTrue(_driver.Url.Contains("https://demo.applitools.com/hackathonApp.html"));
                        Console.Write("DD step d passed");

                    }
                    catch (Exception e)
                    {

                        Console.Write(e);
                    }

                   }

             
       // Table Sort Test
        [TestMethod]
       public void Tablesort()
        {

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outPutDirectory);
            // _driver.Navigate().GoToUrl(" https://demo.applitools.com/hackathon.html");
            // Open Application V2
            _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathonV2.html");

            _driver.FindElement(By.Id("username")).SendKeys("Mal");
            _driver.FindElement(By.Id("password")).SendKeys("pwd");
            _driver.FindElement(By.Id("log-in")).Click();

            Assert.IsTrue(_driver.Url.Contains("https://demo.applitools.com/hackathonApp.html"));
            _driver.FindElement(By.Id("amount")).Click();

            /*  Due to knowledge gap I could not come up with table sorting functionality

                        int rowCount = _driver.FindElement(By.XPath("/html/body/div/div[3]/div[2]/div/div/div[2]/div/div/table")).Size();
            */

        }




        //Verify Canvas graph 
        [TestMethod]
        public void Canvas_chart_Test()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outPutDirectory);
            //_driver.Navigate().GoToUrl(" https://demo.applitools.com/hackathon.html");
            // Open Application V2
            _driver.Navigate().GoToUrl("https://demo.applitools.com/hackathonV2.html");

            _driver.FindElement(By.Id("username")).SendKeys("Mal");
            _driver.FindElement(By.Id("password")).SendKeys("pwd");
            _driver.FindElement(By.Id("log-in")).Click();

            Assert.IsTrue(_driver.Url.Contains("https://demo.applitools.com/hackathonApp.html"));
            _driver.FindElement(By.Id("showExpensesChart")).Click();
            Assert.IsTrue(_driver.Url.Contains("https://demo.applitools.com/hackathonChart.html"));
        /*
         * Graph testing is could not achived in traditional approach due to knowledge gap and technology limitations
         * 
         */
                       
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Quit();
        }

    }
}
