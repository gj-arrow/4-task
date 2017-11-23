using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;

namespace SmartCars.PageObjects
{
    public class TrimComparisonPage : BasePage
    {
        private readonly Label _lblTrimComparisonPage =
            new Label(By.XPath("//div[contains(@class,'trim-header__title')]//h1[contains(text(),'Configurations')]"), "lblCarInfoPage");
        private readonly Label _lblEngine = new Label(By.XPath("//div[contains(@class,'trim-card')][2]//div[4]"));
        private readonly Label _lblTransmission = new Label(By.XPath("//div[contains(@class,'trim-card')][2]//div[5]"));

        public TrimComparisonPage()
        {
            Assert.True(IsTruePage(_lblTrimComparisonPage.GetLocator()), "This is not CarInfoPage");
        }

        public Car GetConfigurationCar()
        {
            var configurationCar = _lblTrimComparisonPage.GetText().Split(' ');
            var car = new Car(configurationCar[1], configurationCar[2], configurationCar[0]);
            return car;
        }

        public CharacteristicsCar SaveCharacteristicsCar()
        {
            var characteristicCar = new CharacteristicsCar(_lblEngine.GetText(), _lblTransmission.GetText());
            return characteristicCar;
        }
    }
}
