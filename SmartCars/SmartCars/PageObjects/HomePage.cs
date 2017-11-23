using System.Threading;
using Framework.Configurations;
using OpenQA.Selenium;
using Framework.Elements;
using NUnit.Framework;
using SmartCars.Elements;

namespace SmartCars.PageObjects
{
    public class HomePage : BasePage
    {
       
        private readonly Button _btnHomePage = 
            new Button(By.XPath("//div/section/a[contains(text(),'Get Started')]"), "btnHomePage");
        private readonly Button _btnResearch =
            new Button(By.XPath("//ul[contains(@class,'global-nav__menu')]//a[contains(text(),'Research')]"), "btnResearch");

        public HomePage() {
            Assert.True(IsTruePage(_btnHomePage.GetLocator()), "This is not HomePage");
        }

        public void NavigateToHome()
        {
            Browser.Driver.Navigate().GoToUrl(Config.Url);
        }

        public void NavigateToResearchPage()
        {
            _btnResearch.ClickAndWait();
        }
    }
}