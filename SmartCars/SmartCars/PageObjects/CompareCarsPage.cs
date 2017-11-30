using System;
using System.Text.RegularExpressions;
using Framework;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;

namespace SmartCars.PageObjects
{
    public class CompareCarsPage : CarsBaseForm
    {
        private const int MatchGroup = 1;
        private const int NumberFirstCar = 0;
        private const string OldValueReplace = "liter";
        private const string NewValueReplace = "L";
        private const string Engine = "Engine", Transmission = "Transmission";
        private const string RegularExpression = "index\">([a-zA-Z0-9-\\/,.(); ]+)";
        private readonly BaseElement _btnAddCar = new BaseElement(By.XPath("//div[@id='icon-div']"), "Add Car button");
        private readonly Label _lblompareCarPage =
            new Label(By.XPath("//div[contains(@class,'side-by-side-head-text')]//h1[contains(text(),'Compare Cars')]"), "btnCompareCarsPage");
        private  SelectElement _selectMake = new SelectElement(By.Id("make-dropdown"), "selectMake");
        private  SelectElement _selectModel = new SelectElement(By.Id("model-dropdown"), "selectModel");
        private  SelectElement _selectYear = new SelectElement(By.Id("year-dropdown"), "selectYear");
        private readonly Button _btnDone = new Button(By.XPath("//button[contains(text(),'Done')]"), "btnDone");
        private readonly Button _btnStartCompare =
            new Button(By.XPath("//form[@id='mainAddCarForm']//button[contains(@class, 'done-button')]"), "btnStartCompare");
        private const string TemplateLocatorForEngineAndTransmission = "//cars-compare-compare-info[contains(@header,'{0}')]//span[@index={1}]";
        private Car _car;

        public CompareCarsPage()
        {
            Assert.True(IsTruePage(_lblompareCarPage), "This is not CompareCarsPage");
        }

        public void SelectCar(Car car)
        {
            _selectMake = new SelectElement(By.Id("make-dropdown"), "selectMake");
            _selectModel = new SelectElement(By.Id("model-dropdown"), "selectModel");
            _selectYear = new SelectElement(By.Id("year-dropdown"), "selectYear");
            _selectMake.SelectValue(car.Make);
            _selectModel.SelectValue(car.Model);
            _selectYear.SelectValue(car.Year);
            _car = new Car(car.Make, car.Model, car.Year);
        }

        public void AddSelectedCarToCompare(int numberCar)
        {
            if (numberCar == NumberFirstCar)
            {
                _btnStartCompare.Click();
            }
            else if (numberCar > NumberFirstCar)
            {
                _btnDone.Click();
            }
            else
            {
                throw new Exception("Number car can't be negative.");
            }
        }

        public void ClickButtonAddCar()
        {
            _btnAddCar.Click();
        }

        public Car GetCharacteristicstCar(int numberCar)
        {
            var elementEngine = new BaseElement(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, Engine, numberCar)), "Label Engine");
            var elementTansmision = new BaseElement(By.XPath(string.Format(TemplateLocatorForEngineAndTransmission, Transmission, numberCar)), "Label Engine");
            var divInnerTextEngine = elementEngine.GetInnerHtml();
            var engine = GetMatchString(RegularExpression, divInnerTextEngine);
            var divInnerTextTransmission = elementTansmision.GetInnerHtml();
            var transmission = GetMatchString(RegularExpression, divInnerTextTransmission);
            var characteristicsCar = new CharacteristicsCar(engine.Replace(OldValueReplace, NewValueReplace), transmission);
            _car.CharacteristicsCar = characteristicsCar;
            return _car;
        }

        public string GetMatchString(string patternStr, string text)
        {
            var resultList = "";
            foreach (Match match in Regex.Matches(text, patternStr, RegexOptions.IgnoreCase))
            {
                resultList += match.Groups[MatchGroup].Value;
            }
            return resultList;
        }
    }
}
