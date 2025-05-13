using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using PageObjectModel.Source.Pages;
using Telenor.page_objects;
using System.IO;
using System;
using System.Diagnostics;

namespace Telenor.tests
{
    public class BredbandTests
    {
        static string chromedriver_path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
        protected IWebDriver driver = new ChromeDriver(chromedriver_path + "\\chromedriver136_0_7103_92");

        [SetUp]
        public void Setup()
        {
            Thread.Sleep(3000); //give chromedriver a few seconds to start
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
            foreach (var process in Process.GetProcessesByName("ChromeDriver"))
            {
                process.Kill();
            }
        }

        [Test]
        public void Fiveg_product_should_display()
        {
            //Home Page
            HomePage home_page = new HomePage(driver);
            home_page.Visit();
            home_page.AcceptAllCookies();
            home_page.handla_menu.Click();
            home_page.bredband_link.Click();

            //Bredband Page
            BredbandPage bredband_page = new BredbandPage(driver);
            bredband_page.address_input.SendKeys("Storgatan 10, Uppsala");
            bredband_page.SelectAddress("Storgatan 10, Uppsala");

            var product_list_items = bredband_page.product_list.FindElements(By.TagName("li"));
            var fiveG_product_displayed = bredband_page.fiveg_product_image.Displayed;

            Assert.GreaterOrEqual(product_list_items.Count, 0);
            Assert.IsTrue(fiveG_product_displayed);
        }
    }
}