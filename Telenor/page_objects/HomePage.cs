using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Telenor.page_objects;

namespace PageObjectModel.Source.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "onetrust-accept-btn-handler")] public IWebElement accept_all_cookies_button;
        [FindsBy(How = How.XPath, Using = "//a[@href='/handla/']")] public IWebElement handla_menu;
        [FindsBy(How = How.XPath, Using = "//div[@class='tn-page-header__slide-down']//a[@href='/handla/bredband/'][@class='cnt-link tn-page-header__sub-item__link']")] public IWebElement bredband_link;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Visit()
        {
            for (int attempts = 0; attempts < 5; attempts++)
            {
                try
                {
                    _driver.Url = "https://www.telenor.se/";
                    Wait(_driver).Until(driver => driver.Title == "Mobil, bredband & Tv hos Telenor | Telenor");
                    break;
                }
                catch 
                {
                    Thread.Sleep(5000);
                }
            }
        }

        public void AcceptAllCookies()
        {
            try
            {
                accept_all_cookies_button.Click();
            }
            catch { }
        }
    }
}
