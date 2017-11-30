using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SmartCars.PageObjects
{
    public class CarInfoPage : CarsBaseForm
    {
        private readonly Label _lblCarInfoPage =
            new Label(By.XPath("//div[contains(@class,'mmy-header__title-year')]//h1"), "Label CarInfoPage");
        private readonly Label _lblTrimComparison =
            new Label(By.XPath("//div[@id='mmy-trims']//a[contains(text(),'trim comparison')]"), "Label TrimComparsion");     

        public CarInfoPage()
        {
            Assert.True(IsTruePage(_lblCarInfoPage), "This is not CarInfoPage");
        }

        public bool IsButtonExists()
        {
            if (_lblTrimComparison.IsExistOnPage())
            {
                return true;
            }
            return false;
        }

        public void NavigateToCarCharacteristics()
        {
            _lblTrimComparison.WaitElement();
            _lblTrimComparison.ClickAndWait();
        }
    }
}
