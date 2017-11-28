using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework;
using Framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartCars.Entities;

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
        private readonly Button _btnResearch =
            new Button(By.XPath("//ul[contains(@class,'global-nav__menu')]//a[contains(text(),'Research')]"), "btnResearch");

        public CarInfoPage()
        {
            Assert.True(IsTruePage(_lblCarInfoPage), "This is not CarInfoPage");
        }

        public bool IsButtonExists()
        {
            if (_lblTrimComparison.IsExistOnPage())
            {
                return true;
            }
            return false;
        }

        public void NavigateToResearchPage()
        {
            _btnResearch.ClickAndWait();
        }

        public void NavigateToCarCharacteristics()
        {
            _btnTrims.Click();
            _lblTrimComparison.ClickAndWait();
        }
    }
}
