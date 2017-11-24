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
        private readonly Label _lblompareCarPage =
            new Label(By.XPath("//div[contains(@class,'side-by-side-head-text')]//h1[contains(text(),'Compare Cars')]"), "btnCompareCarsPage");
        private readonly SelectElement _selectMake = new SelectElement(By.Id("make-dropdown"), "selectCar");
        private readonly SelectElement _selectModel = new SelectElement(By.Id("model-dropdown"), "selectModel");
        private readonly SelectElement _selectYear = new SelectElement(By.Id("year-dropdown"), "selectYear");
        private readonly Button _btnStartCompare = new Button(By.XPath("//form[@id='mainAddCarForm']//button[contains(@class, 'done-button')]"), "btnStartCompare");
   
        //private readonly Button _btnAddCar =
        //    new Button(By.Name("plus-line"), "btnAddCar");
        private readonly Label _lblEngine =
            new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Engine')]//span[@index=0]//p"), "lblEngine");
        //private readonly Label _lblEngine2 =
        //    new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Engine')]//span[@index=1]//p"), "lblEngine2");
        private readonly Label _lblTansmision =
            new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Transmission')]//span[@index=0]//p"), "lblEngine");
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
            Button _btnAddCar = new Button(By.Name("plus-line"), "btnAddCar");
            _btnAddCar.Click();
            Button _btnDone = new Button(By.XPath("//div[contains(@class,'modal-footer')]/button[contains(@class,'modal-button')]"), "btnDone");
            SelectElement _selectMake1 = new SelectElement(By.Id("make-dropdown"), "selectCar");
            SelectElement _selectModel1 = new SelectElement(By.Id("model-dropdown"), "selectModel");
            SelectElement _selectYear1 = new SelectElement(By.Id("year-dropdown"), "selectYear");
            _selectMake1.SelectValue(car.Make);
            _selectModel1.SelectValue(car.Model);
            _selectYear1.SelectValue(car.Year);
            _btnDone.Click();
        }

        public CharacteristicsCar GetCharacteristicsFirstCar()
        {
            var characteristicsCar = new CharacteristicsCar(_lblEngine.GetText().Replace("liter", "L"), _lblTansmision.GetText().Replace("spd", "speed"));
            return characteristicsCar;
        }

        public CharacteristicsCar GetCharacteristicsSecondCar()
        {
            Label _lblEngine2 =
                new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Engine')]//span[@index=1]//p"), "lblEngine2");
            Label _lblTansmision2 =
            new Label(By.XPath("//cars-compare-compare-info[contains(@header,'Transmission')]//span[@index=1]//p"), "lblEngine2");
            var characteristicsCar = new CharacteristicsCar(_lblEngine2.GetText().Replace("liter", "L"), _lblTansmision2.GetText().Replace("spd", "speed"));
            return characteristicsCar;
        }
    }
}
