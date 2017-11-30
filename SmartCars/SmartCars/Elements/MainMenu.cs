using Framework;
using Framework.Elements;
using OpenQA.Selenium;

namespace SmartCars.Elements
{
    public class MainMenu : BasePage
    {
        private Label _lblMenuItem;
        private const string TemplateMenuLocator = "//ul[contains(@class,'global-nav__menu')]//a[contains(text(), '{0}')]";

        public MainMenu(By locator, string name) : base (locator, name)
        {
        }

        public void NavigateToMenuItem(string topLevelMenuItem)
        {
            _lblMenuItem = new Label(By.XPath(string.Format(TemplateMenuLocator, topLevelMenuItem)), "lblMainMenuItem");
            _lblMenuItem.ClickAndWait();
        }
    }
}
