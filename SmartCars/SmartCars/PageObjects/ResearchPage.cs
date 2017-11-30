using System;
using System.Collections.Generic;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;

namespace SmartCars.PageObjects 
{
    public class ResearchPage : CarsBaseForm
    {
        private static readonly Random Random = new Random();
        private const int StartIndex = 1;
        private const string TemplateSelectLocator = "//section[@id='research-search-widget']//div[contains(@class,'{0}')]//select";
        private readonly Label _btnResearchPage =
            new Label(By.XPath("//section[@id='research-browseby']/h2[contains(text(),'Research')]"), "Label ResearchPage");
        private  readonly  SelectElement _selectCar = 
            new SelectElement(By.XPath(string.Format(TemplateSelectLocator, "hsw-make")), "selectMake");
        private readonly SelectElement _selectModel =
            new SelectElement(By.XPath(string.Format(TemplateSelectLocator, "hsw-model")), "selectModel");
        private readonly SelectElement _selectYear =
            new SelectElement(By.XPath(string.Format(TemplateSelectLocator, "hsw-year")), "selectYear");
        private  readonly  Button _btnSearch = 
            new Button(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-submit')]//input[@type='submit']"), "Button Submit");
        private readonly Button _btnCompareCars =
            new Button(By.XPath("//div[@id='ta-linkcards-container']//a[contains(@data-link-name,'compare-cars')]"), "Button CompareCars");

        public ResearchPage()
        {
            Assert.True(IsTruePage(_btnResearchPage), "This is not ResearchPage");
        }

        public void NavigateToCompareCarsPage()
        {
            _btnCompareCars.ClickAndWait();
        }

        public void SelectRandomCar()
        {
            var cars = _selectCar.Options();
            _selectCar.SelectValue(RandomValue(cars));
            var models = _selectModel.Options();
            _selectModel.SelectValue(RandomValue(models));
            var years = _selectYear.Options();
            _selectYear.SelectValue(RandomValue(years));
        }

        public Car GetCarInfo()
        {
            var car = new Car(_selectCar.SelectedOption(), _selectModel.SelectedOption(), _selectYear.SelectedOption());
            return car;
        }

        private static string RandomValue(List<string> options)
        {
            var randomIndex = Random.Next(StartIndex, options.Count);
            return options[randomIndex];
        }

        public void ClickSearchButton()
        {
            _btnSearch.ClickAndWait();
        }
    }
}
