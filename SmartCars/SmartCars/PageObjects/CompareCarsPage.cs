using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;
using SmartCars.Utils;

namespace SmartCars.PageObjects
{
    public class CompareCarsPage : BasePage
    {
        private Label _lblEngine2, _lblTansmision2;
        private readonly Element _btnAddCar = new Element(By.XPath("//div[@id='icon-div']"), "Add Car button");
        private readonly Label _lblompareCarPage =
            new Label(By.XPath("//div[contains(@class,'side-by-side-head-text')]//h1[contains(text(),'Compare Cars')]"), "btnCompareCarsPage");
        private readonly SelectElement _selectMake = new SelectElement(By.Id("make-dropdown"), "selectMake");
        private readonly SelectElement _selectModel = new SelectElement(By.Id("model-dropdown"), "selectModel");
        private readonly SelectElement _selectYear = new SelectElement(By.Id("year-dropdown"), "selectYear");
        private readonly Button _btnDone = new Button(By.XPath("//button[contains(text(),'Done')]"), "btnDone");
        //private readonly SelectElement _selectMakeSecond = new SelectElement(By.Id("make-dropdown"), "selectCar");
        //private readonly SelectElement _selectModelSecond = new SelectElement(By.Id("model-dropdown"), "selectModel");
        //private readonly SelectElement _selectYearSecond = new SelectElement(By.Id("year-dropdown"), "selectYear");
        private readonly Button _btnStartCompare =
            new Button(By.XPath("//form[@id='mainAddCarForm']//button[contains(@class, 'done-button')]"),
                "btnStartCompare");
        private const string TemplateLocatorForEngineAndTransmission = "//cars-compare-compare-info[contains(@header,'{0}')]//span[@index={1}]//p";
        private readonly Label _lblEngine =
            new Label(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission,"Engine",0)), "lblEngine");
        private readonly Label _lblTansmision =
            new Label(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, "Transmission", 0)), "lblEngine");


        //private readonly Label _lblEngine2 =
        //    new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Engine')]//span[@index=1]//p"), "lblEngine2");
        //private readonly Label _lblTansmision2 =
        //    new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Transmission')]//span[@index=1]//p"), "lblEngine2");

        public CompareCarsPage()
        {
            Assert.True(IsTruePage(_lblompareCarPage.GetLocator()), "This is not CompareCarsPage");
        }

        public Car SelectFirstCar(Car car)
        {
            _selectMake.SelectValue(car.Make);
            _selectModel.SelectValue(car.Model);
            _selectYear.SelectValue(car.Year);
            var resultCar = new Car(_selectMake.SelectedOption(), _selectModel.SelectedOption(), _selectYear.SelectedOption());
            _btnStartCompare.Click();
            return resultCar;
        }

        public void AddCar(Car car)
        {
            _btnAddCar.Click();
            SelectElement _selectMakeSecond = new SelectElement(By.Id("make-dropdown"), "selectCar");
            SelectElement _selectModelSecond = new SelectElement(By.Id("model-dropdown"), "selectModel");
            SelectElement _selectYearSecond = new SelectElement(By.Id("year-dropdown"), "selectYear");
            _selectMakeSecond.SelectValue(car.Make);
            _selectModelSecond.SelectValue(car.Model);
            _selectYearSecond.SelectValue(car.Year);
            _btnDone.Click();
        }

        public CharacteristicsCar GetCharacteristicsFirstCar()
        {
            var characteristicsCar = new CharacteristicsCar(_lblEngine.GetText().Replace("liter", "L"), _lblTansmision.GetText().Replace("spd", "speed"));
            return characteristicsCar;
        }

        public CharacteristicsCar GetCharacteristicsSecondCar()
        {
            _lblEngine2 =
                new Label(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, "Engine", 1)), "lblEngine2");
            _lblTansmision2 =
            new Label(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, "Transmission", 1)), "lblEngine2");
            var characteristicsCar = new CharacteristicsCar(_lblEngine2.GetText().Replace("liter", "L"), _lblTansmision2.GetText().Replace("spd", "speed"));
            return characteristicsCar;
        }
    }
}
