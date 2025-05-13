using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Telenor.page_objects;

namespace PageObjectModel.Source.Pages
{
    public class BredbandPage : BasePage
    {

        private IWebDriver _driver;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Sök adress']")] public IWebElement address_input;
        [FindsBy(How = How.Id, Using = "address-list")] public IWebElement address_list;
        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Sökresultat']")] public IWebElement product_list;
        [FindsBy(How = How.XPath, Using = "//img[@alt='Bredband via 5G']")] public IWebElement fiveg_product_image;
        [FindsBy(How = How.XPath, Using = "//label[text()='Boendealternativ eller lägenhetsnummer']/following-sibling::div/select")] public IWebElement apartment_number_select;

        public BredbandPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void SelectRandomAddress()
        {
            Wait(_driver).Until(driver => address_list.Displayed);
            var address_results = address_list.FindElements(By.TagName("li"));
            Random random = new Random();
            int randomIndex = random.Next(address_results.Count);
            Actions actions = new Actions(_driver);
            actions.ScrollToElement(address_results[address_results.Count - 1]).Perform();
            address_results[randomIndex].Click();
        }

        public void SelectAddress(string address)
        {
            address = address.ToUpper();
            Wait(_driver).Until(driver => address_list.Displayed);
            address_list.FindElement(By.XPath($"//li[text()='{address}']")).Click(); ;
        }
    }
}