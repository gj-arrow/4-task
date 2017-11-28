using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using Framework.Configurations;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Elements;
using SmartCars.Entities;
using SmartCars.Services;
namespace SmartCars.PageObjects
{
    public class CompareCarsPage : BasePage
    {      
        private const string RegularExpression = "index\">([a-zA-Z0-9-\\/,.() ]+)";
       // private Label _lblEngine2, _lblTansmision2;
        private readonly BaseElement _btnAddCar = new BaseElement(By.XPath("//div[@id='icon-div']"), "Add Car button");
        private readonly Label _lblompareCarPage =
            new Label(By.XPath("//div[contains(@class,'side-by-side-head-text')]//h1[contains(text(),'Compare Cars')]"), "btnCompareCarsPage");
        private readonly SelectElement _selectMake = new SelectElement(By.Id("make-dropdown"), "selectMake");
        private readonly SelectElement _selectModel = new SelectElement(By.Id("model-dropdown"), "selectModel");
        private readonly SelectElement _selectYear = new SelectElement(By.Id("year-dropdown"), "selectYear");
        private readonly Button _btnDone = new Button(By.XPath("//button[contains(text(),'Done')]"), "btnDone");
        private readonly Button _btnStartCompare =
            new Button(By.XPath("//form[@id='mainAddCarForm']//button[contains(@class, 'done-button')]"),
                "btnStartCompare");
        private const string TemplateLocatorForEngineAndTransmission = "//cars-compare-compare-info[contains(@header,'{0}')]//span[@index={1}]";
        private readonly Table _tblEngine =
            new Table(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission,"Engine",0)), "lblEngine");
        private readonly Table _tblTansmision =
            new Table(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, "Transmission", 0)), "lblEngine");

        public CompareCarsPage()
        {
            Assert.True(IsTruePage(_lblompareCarPage), "This is not CompareCarsPage");
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
            var divInnerTextEngine = _tblEngine.GetInnerHtml();
            var engine = RegexService.GetMatchString(RegularExpression, divInnerTextEngine);
            var divInnerTextTransmission = _tblTansmision.GetInnerHtml();
            var transmission = RegexService.GetMatchString(RegularExpression, divInnerTextTransmission);
            var characteristicsCar = new CharacteristicsCar(engine.Replace("liter", "L"), transmission.Replace("spd", "speed"));
            return characteristicsCar;
        }

        public CharacteristicsCar GetCharacteristicsSecondCar()
        {
            var tblEngine2 = new Table(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, "Engine", 1)), "lblEngine2");
            var tblTansmision2 = new Table(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, "Transmission", 1)), "lblEngine2");
            var divInnerTextEngine = tblEngine2.GetInnerHtml();
            var engine = RegexService.GetMatchString(RegularExpression, divInnerTextEngine);
            var divInnerTextTransmission = tblTansmision2.GetInnerHtml();
            var transmission = RegexService.GetMatchString(RegularExpression, divInnerTextTransmission);
            var characteristicsCar = new CharacteristicsCar(engine.Replace("liter", "L"), transmission.Replace("spd", "speed"));
            return characteristicsCar;
        }
    }
}
