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
        private readonly Label _lblEngine = new Label(By.XPath("//div[contains(@class,'trim-card')][2]//div[4]"), "lblEngine");
        private readonly Label _lblTransmission = new Label(By.XPath("//div[contains(@class,'trim-card')][2]//div[5]"), "lblTransmission");
        private readonly Label _btnMake = new Label(By.XPath("//a[contains(@data-linkname,'bc-Make')]"), "btnMake");
        private readonly Label _btnModel = new Label(By.XPath("//a[contains(@data-linkname,'bc-Model')]"), "btnModel");
        private readonly Button _btnResearch =
            new Button(By.XPath("//ul[contains(@class,'global-nav__menu')]//a[contains(text(),'Research')]"), "btnResearch");

        public TrimComparisonPage()
        {
            Assert.True(Browser.Driver.Url.EndsWith("trims/"));
        }

        public void NavigateToResearchPage()
        {
            _btnResearch.ClickAndWait();
        }

        public Car GetConfigurationCar()
        {
            if (_lblTrimComparisonPage.IsExistOnPage())
            {
                var configurationCar = _lblTrimComparisonPage.GetText().Split(' ');
                var car = new Car(_btnMake.GetText(), _btnModel.GetText(), configurationCar[0]);
                return car;
            }
            return null;
        }

        public CharacteristicsCar SaveCharacteristicsCar()
        {
            var characteristicCar = 
                new CharacteristicsCar(_lblEngine.GetText().Replace("liter", "L"), _lblTransmission.GetText().Replace("spd", "speed"));
            return characteristicCar;
        }
    }
}
