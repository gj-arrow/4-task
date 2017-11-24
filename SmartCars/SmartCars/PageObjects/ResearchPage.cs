﻿using System;
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
    public class ResearchPage : BasePage
    {
        private readonly Button _btnResearchPage =
            new Button(By.XPath("//section[@id='research-browseby']/h2[contains(text(),'Research')]"), "btnResearchPage");
        private  readonly  SelectElement _selectCar = 
            new SelectElement(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-makes')]//select"));
        private readonly SelectElement _selectModel =
            new SelectElement(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-models')]//select"));
        private readonly SelectElement _selectYear =
            new SelectElement(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-years')]//select"));
        private  readonly  Button _btnSubmit = 
            new Button(By.XPath("//section[@id='research-search-widget']//div[contains(@class,'hsw-submit')]//input[@type='submit']"));
        private readonly Button _btnCompareCars =
            new Button(By.XPath("//div[@id='ta-linkcards-container']//a[contains(@data-link-name,'compare-cars')]"), "btnCompareCars");

        public ResearchPage()
        {
            Assert.True(IsTruePage(_btnResearchPage.GetLocator()), "This is not ResearchPage");
        }

        public void NavigateToCompareCarsPage()
        {
            _btnCompareCars.ClickAndWait();
        }

        public Car SearchRandomCar()
        {
            var cars = _selectCar.Options();
            _selectCar.SelectValue(RandomUtil.RandomValue(cars));
            var models = _selectModel.Options();
            _selectModel.SelectValue(RandomUtil.RandomValue(models));
            var years = _selectYear.Options();
            _selectYear.SelectValue(RandomUtil.RandomValue(years));
            var car = new Car(_selectCar.SelectedOption(), _selectModel.SelectedOption(), _selectYear.SelectedOption());
            _btnSubmit.ClickAndWait();
            return car;
        }
    }
}
