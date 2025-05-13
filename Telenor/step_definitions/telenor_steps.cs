using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectModel.Source.Pages;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Telenor.step_definitions
{
    [Binding]
    public class telenor_steps
    {
        static string chromedriver_path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));
        static protected IWebDriver driver = new ChromeDriver(chromedriver_path + "\\chromedriver136_0_7103_92");
        static HomePage home_page = new HomePage(driver);
        static BredbandPage bredband_page = new BredbandPage(driver);

        [BeforeFeature]
        static public void InitFeature()
        {
            Thread.Sleep(3000); //give chromedriver a few seconds to start
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [AfterFeature]
        static public void TearDownFeature()
        {
            driver.Close();
            driver.Quit();
            foreach (var process in Process.GetProcessesByName("ChromeDriver"))
            {
                process.Kill();
            }
        }


        [Given(@"I am on the Telenor home page")]
        public void GivenIAmOnTheTelenorHomePage()
        {         
            home_page.Visit();
            home_page.AcceptAllCookies();
        }

        [Given(@"I navigate to the Bredband page from the main menu")]
        public void GivenINavigateToTheBredbandPageFromTheMainMenu()
        {
            home_page.handla_menu.Click();
            home_page.bredband_link.Click();
        }

        [When(@"I search for products at an apartment address")]
        public void WhenISearchForProductsAtAnApartmentAddress()
        {
            bredband_page.address_input.SendKeys("Storgatan 1, Uppsala");
            bredband_page.SelectAddress("Storgatan 1, Uppsala");
        }

        [When(@"I search for products at a non-apartment address")]
        public void WhenISearchForProductsAtANonApartmentAddress()
        {
            bredband_page.address_input.SendKeys("Storgatan 10, Uppsala");
            bredband_page.SelectAddress("Storgatan 10, Uppsala");
        }

        [When(@"I select my apartment from the list")]
        public void WhenISelectMyApartmentFromTheList()
        {
            bredband_page.SelectApartmentNumber("0004");
        }

        [Then(@"the 5G internet product should be displayed")]
        public void ThenThe5GInternetProductShouldBeDisplayed()
        {
            var product_list_items = bredband_page.product_list.FindElements(By.TagName("li"));
            var fiveG_product_displayed = bredband_page.fiveg_product_image.Displayed;

            Assert.GreaterOrEqual(product_list_items.Count, 0);
            Assert.IsTrue(fiveG_product_displayed);
        }

    }
}
