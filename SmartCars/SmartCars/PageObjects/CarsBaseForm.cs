using Framework;
using OpenQA.Selenium;

namespace SmartCars.PageObjects
{
    public class CarsBaseForm : BasePage
    {
        private readonly MainMenu _mainMenu = new MainMenu(By.XPath("//ul[contains(@class,'global-nav__menu')]"), "MainMenu");
        private readonly CarInfoMenu _carInfoMenu = new CarInfoMenu(By.XPath("//div[contains(@class,'menu-parent ng-scope')]"), "CarInfoMenu");

        public MainMenu GetMainMenu()
        {
            return _mainMenu;
        }

        public CarInfoMenu GetCarInfoMenu()
        {
            return _carInfoMenu;
        }
    }
}
