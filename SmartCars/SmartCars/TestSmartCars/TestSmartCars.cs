using System;
using NUnit.Framework;
using SmartCars.PageObjects;
using Framework.BrowserManager;
using Framework.Configurations;
using SmartCars.Entities;

namespace SmartCars.TestSmartCars
{
    public class TestSmartCars
    {
        private BrowserFactory _browserFactory;
        private Car carExpected, carActual;

        [SetUp]
        public void Initialize()
        {
            _browserFactory = BrowserFactory.GetInstance();
            _browserFactory.InitBrowser(Config.Browser);
            _browserFactory.Driver.Manage().Window.Maximize();
            _browserFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Config.ImplicitWait);
            _browserFactory.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Config.ExplicitWait);
            _browserFactory.Driver.Navigate().GoToUrl(Config.Url);
        }

        [TearDown]
        public void Dispose()
        {
            _browserFactory.CloseDriver();
        }

        [Test]
        public void AutoTestSteampowered()
        {
            var flag = false;
            var homePage = new HomePage();
            while (!flag)
            {
                homePage.NavigateToHome();
                homePage.NavigateToResearchPage();

                var researchPage = new ResearchPage();
                carExpected = researchPage.SearchRandomCar();

                var carInfoPage = new CarInfoPage();
              flag = carInfoPage.NavigateToCarCharacteristics();
            }
            var trimComparisonPage = new TrimComparisonPage();
            carActual = trimComparisonPage.GetConfigurationCar();
            Assert.True(Car.Equals(carExpected, carActual),"Cars don't match");
            var characteristicCar = trimComparisonPage.SaveCharacteristicsCar();
            homePage.NavigateToHome();
        }
    }
}
