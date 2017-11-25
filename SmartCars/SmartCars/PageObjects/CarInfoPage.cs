using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;
using SmartCars.Utils;

namespace SmartCars.PageObjects
{
    public class CarInfoPage : BasePage
    {
        private readonly Label _lblCarInfoPage =
            new Label(By.XPath("//div[contains(@class,'mmy-header__title-year')]//h1"), "lblCarInfoPage");
        private readonly Label _lblTrimComparison =
            new Label(By.XPath("//div[@id='mmy-trims']//a[contains(text(),'trim comparison')]"), "lblTrimComparsion");
        private readonly Button _btnTrims =
            new Button(By.XPath("//div[contains(@class,'cui-page-container')]//div[contains(@class,'menu-parent')]//a[contains(text(),'Trims')]"));

        public CarInfoPage()
        {
            Assert.True(IsTruePage(_lblCarInfoPage.GetLocator()), "This is not CarInfoPage");
        }

        public bool NavigateToCarCharacteristics()
        {
            if (_lblTrimComparison.IsExistOnPage())
            {
                _btnTrims.Click();
                _lblTrimComparison.ClickAndWait();
                return true;
            }
            return  false;
        }
    }
}
