using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;
using SmartCars.Services;

namespace SmartCars.PageObjects 
{
    public class ResearchPage : BasePage
    {
        private readonly Label _btnResearchPage =
            new Label(By.XPath("//section[@id='research-browseby']/h2[contains(text(),'Research')]"), "lblResearchPage");
        private  readonly  SelectElement _selectCar = 
            new SelectElement(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-makes')]//select"), "selectMake");
        private readonly SelectElement _selectModel =
            new SelectElement(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-models')]//select"), "selectModel");
        private readonly SelectElement _selectYear =
            new SelectElement(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-years')]//select"), "selectYear");
        private  readonly  Button _btnSubmit = 
            new Button(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-submit')]//input[@type='submit']"), "btnSubmit");
        private readonly Button _btnCompareCars =
            new Button(By.XPath("//div[@id='ta-linkcards-container']//a[contains(@data-link-name,'compare-cars')]"), "btnCompareCars");

        public ResearchPage()
        {
            Assert.True(IsTruePage(_btnResearchPage), "This is not ResearchPage");
        }

        public void NavigateToCompareCarsPage()
        {
            _btnCompareCars.ClickAndWait();
        }

        public Car SelectRandomCar()
        {
            var cars = _selectCar.Options();
            _selectCar.SelectValue(RandomService.RandomValue(cars));
            var models = _selectModel.Options();
            _selectModel.SelectValue(RandomService.RandomValue(models));
            var years = _selectYear.Options();
            _selectYear.SelectValue(RandomService.RandomValue(years));
            var car = new Car(_selectCar.SelectedOption(), _selectModel.SelectedOption(), _selectYear.SelectedOption());
            return car;
        }

        public void ClickSearchButton()
        {
            _btnSubmit.ClickAndWait();
        }
    }
}
