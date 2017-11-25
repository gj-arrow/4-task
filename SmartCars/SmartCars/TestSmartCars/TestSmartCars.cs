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
        private Car carExpected1, carActual1, carExpected2, carActual2;
        private TrimComparisonPage trimComparisonPage;

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
            var flag1 = false;
            var homePage = new HomePage();
            while (!flag1)
            {
                homePage.NavigateToHome();
                homePage.NavigateToResearchPage();

                var researchPage = new ResearchPage();
                carExpected1 = researchPage.SearchRandomCar();

                var carInfoPage = new CarInfoPage();
                flag1 = carInfoPage.NavigateToCarCharacteristics();
            }
            trimComparisonPage = new TrimComparisonPage();
            carActual1 = trimComparisonPage.GetConfigurationCar();
            Assert.True(Car.Equals(carExpected1, carActual1),"Cars don't match");
            var characteristicExpectedCar1 = trimComparisonPage.SaveCharacteristicsCar();
            homePage.NavigateToHome();

            var flag2 = false;
            while (!flag2)
            {
                homePage.NavigateToHome();
                homePage.NavigateToResearchPage();

                var researchPage = new ResearchPage();
                carExpected2 = researchPage.SearchRandomCar();

                var carInfoPage = new CarInfoPage();
                flag2 = carInfoPage.NavigateToCarCharacteristics();
            }
            trimComparisonPage = new TrimComparisonPage();
            carActual2 = trimComparisonPage.GetConfigurationCar();
            Assert.True(Car.Equals(carExpected2, carActual2), "Cars don't match");
            var characteristicExpectedCar2 = trimComparisonPage.SaveCharacteristicsCar();
            trimComparisonPage.NavigateToResearchPage();
            var researchPage2 = new ResearchPage();
            researchPage2.NavigateToCompareCarsPage();
            var compareCarsPage = new CompareCarsPage();
            compareCarsPage.SelectFirstCar(carActual1);
            compareCarsPage.AddCar(carActual2);
            var characteristicCarActual1 = compareCarsPage.GetCharacteristicsFirstCar();
            var characteristicCarActual2 = compareCarsPage.GetCharacteristicsSecondCar();
            Assert.True(CharacteristicsCar.Equals(characteristicExpectedCar1, characteristicCarActual1), "1 not match "
                + characteristicExpectedCar1.Engine + "||||" + characteristicCarActual1.Engine+ "      " + 
                characteristicExpectedCar1.Transmission + "||||" + characteristicCarActual1.Transmission);
            Assert.True(CharacteristicsCar.Equals(characteristicExpectedCar2, characteristicCarActual2), "2 not match "
                + characteristicExpectedCar2.Engine + "||||" + characteristicCarActual2.Engine + "      " +
                characteristicExpectedCar2.Transmission + "||||" + characteristicCarActual2.Transmission);
        }



        [Test]
        public void AutoTest()
        {
            var flag1 = false;
            var homePage = new HomePage();
            while (!flag1)
            {
                homePage.NavigateToHome();
                homePage.NavigateToResearchPage();

                var researchPage = new ResearchPage();
                carExpected1 = researchPage.SearchCarTest();

                var carInfoPage = new CarInfoPage();
                flag1 = carInfoPage.NavigateToCarCharacteristics();
            }
            trimComparisonPage = new TrimComparisonPage();
            carActual1 = trimComparisonPage.GetConfigurationCar();
            Assert.True(Car.Equals(carExpected1, carActual1), "Cars don't match");
            var characteristicExpectedCar1 = trimComparisonPage.SaveCharacteristicsCar();
            homePage.NavigateToHome();
        }
    }
}
