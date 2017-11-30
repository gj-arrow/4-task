using System;
using Framework.BrowserManager;
using OpenQA.Selenium;

namespace Framework
{
    public abstract class BasePage
    {
        protected By Locator;
        protected string Name;
        protected Browser Browser;

        protected BasePage()
        {
            Browser = Browser.GetInstance();
        }

        protected BasePage(By locator, string name)
        {
            Browser = Browser.GetInstance();
            Locator = locator;
            Name = name;
        }

        protected bool IsTruePage(BaseElement element)
        {
            try
            {
                element.IsExistOnPage();
            }
            catch (Exception e)
            {
                Console.WriteLine("The expected page wasn't displayed." + e.Message);
                return false;
            }
            return true;
        }
    }
}
