using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.BrowserManager;
using Framework.Configurations;
using OpenQA.Selenium.Interactions;

namespace Framework
{
    public class BaseElement
    {
        public static Browser Browser = Browser.GetInstance();
        public IWebElement Element;
        public By Locator;
        public string Name;
        public WebDriverWait Wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Config.ExplicitWait));

        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        public BaseElement(By locator)
        {
            this.Locator = locator;
        }

        public BaseElement()
        {
        }

        public string GetName()
        {
            WaitUntilDisplayed();
            return Name; 
        }

        public string GetText()
        {
            WaitUntilDisplayed();
            return Element.Text; 
        }

        public IWebElement WaitUntilDisplayed()
        {
            Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Locator));
            Wait.Until(drv => drv.FindElement(Locator).Displayed && drv.FindElement(Locator).Enabled);
            Element = Browser.GetDriver().FindElement(Locator);
            return Element;
        }

        public IWebElement WaitUntilClickable()
        {
            WaitUntilDisplayed();
            Element = Wait.Until(ExpectedConditions.ElementToBeClickable(Locator));
            return Element;
        }

        public IWebElement WaitUntilElementExists()
        {
            Element = Wait.Until(ExpectedConditions.ElementExists(Locator));
            return Element;
        }

        public IWebElement GetInnerElement(By innerLocator)
        {
            WaitUntilDisplayed();
            var innerElement = Element.FindElement(innerLocator);
            return innerElement;
        }

        public void ClickAndWait()
        {
            WaitUntilElementExists();
            WaitUntilClickable();
            Element.Click();
            Wait.Until(ExpectedConditions.StalenessOf(Element));
        }

        public void WaitElement()
        {
            WaitUntilElementExists();
            WaitUntilDisplayed();
            WaitUntilClickable();
        }

        public void Click()
        {
            WaitUntilClickable();
            Element.Click();
        }

        public void MoveAndClick()
        {
            ScrollToElement();
            var actions = new Actions(Browser.GetDriver());
            WaitUntilClickable();
            actions.MoveToElement(Element).Click().Build().Perform();
        }

        public void ScrollToElement()
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Config.ExplicitWait));
            var webElement = wait.Until(ExpectedConditions.ElementToBeClickable(Locator));
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public bool IsExistOnPage()
        {
            if (Browser.GetDriver().FindElements(Locator).Count != 0)
            {
                return true;
            }
            return false;
        }

        public void MoveToElement()
        {
            WaitUntilDisplayed();
            var mouse = new Actions(Browser.GetDriver());
            mouse.MoveToElement(Element).Build().Perform();
        }

        public string GetAttribute(string attribute)
        {
            var textAttribute = Element.GetAttribute(attribute);
            return textAttribute;
        }

        public string GetInnerHtml()
        {
            WaitUntilDisplayed();
            var locatorToDiscountGames = Element.GetAttribute("innerHTML");
            return locatorToDiscountGames;
        }
    }
}
