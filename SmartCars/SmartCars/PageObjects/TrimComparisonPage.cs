using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;

namespace SmartCars.PageObjects
{
    public class TrimComparisonPage : CarsBaseForm
    {
        private const char Separator = ' ';
        private const int FirstWord = 0;
        private const string OldValueReplace = "liter";
        private const string NewValueReplace = "L";
        private readonly Label _lblTrimComparisonPage =
            new Label(By.XPath("//div[contains(@class,'trim-header__title')]//h1[contains(text(),'Configurations')]"), "Label CarInfoPage");
        private readonly Label _lblEngine = new Label(By.XPath("//div[contains(@class, 'trim-card')]/div[contains(text(), 'hp')]"), "Label Engine");
        private readonly Label _lblTransmission = new Label(By.XPath("//div[contains(@class, 'trim-card')]/div[contains(text(), 'speed')]"), "Label Transmission");
        private readonly Label _btnMake = new Label(By.XPath("//a[contains(@data-linkname,'bc-Make')]"), "Button Make");
        private readonly Label _btnModel = new Label(By.XPath("//a[contains(@data-linkname,'bc-Model')]"), "Button Model");

        public TrimComparisonPage()
        {
            Assert.True(Browser.GetUrl().EndsWith("trims/"), "This is not TrimComprasionPage");
        }

        public Car GetConfigurationCar()
        {
            if (_lblTrimComparisonPage.IsExistOnPage())
            {
                var carInfo = _lblTrimComparisonPage.GetText().Split(Separator);
                var car = new Car(_btnMake.GetText(), _btnModel.GetText(), carInfo[FirstWord]);
                return car;
            }
            return null;
        }

        public CharacteristicsCar SaveCharacteristicsCar()
        {
            var characteristicCar = 
                new CharacteristicsCar(_lblEngine.GetText().Replace(OldValueReplace, NewValueReplace), _lblTransmission.GetText());
            return characteristicCar;
        }
    }
}
