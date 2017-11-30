using Framework;
using Framework.Elements;
using OpenQA.Selenium;

namespace SmartCars.PageObjects
{
    public class CarInfoMenu : BasePage
    {
        private Label _lblMenuItem;
        private const string TemplateMenuLocator = "//div[contains(@class, 'menu-parent ng-scope')]//a[contains(text(), {0})]";

        public CarInfoMenu(By locator, string name) : base (locator, name)
        {
        }

        public void NavigateToMenuItem(string topLevelMenuItem)
        {
            _lblMenuItem = new Label(By.XPath(string.Format(TemplateMenuLocator, topLevelMenuItem)), "Label CarInfoMenuItem");
            _lblMenuItem.Click();
        }
    }
}
