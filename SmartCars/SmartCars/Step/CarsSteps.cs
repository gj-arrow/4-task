using System;
using System.Collections.Generic;
using System.Linq;
using Framework.BrowserManager;
using Framework.Configurations;
using NUnit.Framework;
using SmartCars.Entities;
using SmartCars.PageObjects;
using TechTalk.SpecFlow;

namespace SmartCars.Step
{
    [Binding]
    public class CarsSteps
    {
        private Browser _browser;
        private List<Car> carExpected = new List<Car>();
        private List<Car> carActual = new List<Car>();
        private List<CharacteristicsCar> engineAndTransmissionExpected = new List<CharacteristicsCar>();
        private List<CharacteristicsCar> engineAndTransmissionActual = new List<CharacteristicsCar>();
        private TrimComparisonPage trimComparisonPage;
        private HomePage homePage;
        private ResearchPage researchPage;
        private CarInfoPage carInfoPage;
        private CompareCarsPage compareCarsPage;

        [Before()]
        public void Before()
        {
            _browser = Browser.GetInstance();
            _browser.GoToUrl(Config.Url);
        }

        [After()]
        public void After()
        {
            _browser.CloseDriver();
        }

        [Given(@"User navigate to cars\.com")]
        public void GivenUserNavigateToCars_Com()
        {
            homePage = new HomePage();
            homePage.NavigateToHome();
        }
        
        [When(@"Navigate to Research")]
        public void WhenNavigateToResearch()
        {
            homePage.NavigateToResearchPage();
        }
        
        [When(@"Select random car")]
        public void WhenSelectRandomCar()
        {
            researchPage = new ResearchPage();
            carExpected.Add(researchPage.SelectRandomCar());
        }
        
        [When(@"Click Search button")]
        public void WhenClickSearchButton()
        {
            researchPage.ClickSearchButton();
        }

        [When(@"Click first trim")]
        public void WhenClickFirstTrim()
        {
            carInfoPage = new CarInfoPage();
            if (carInfoPage.IsButtonExists())
            {
                carInfoPage.NavigateToCarCharacteristics();
            }
            else
            {
                while (!carInfoPage.IsButtonExists())
                {
                    carExpected.Remove(carExpected.Last());
                    carInfoPage.NavigateToResearchPage();
                    WhenSelectRandomCar();
                    WhenClickSearchButton();
                    carInfoPage = new CarInfoPage();
                    if (carInfoPage.IsButtonExists())
                    {
                        carInfoPage.NavigateToCarCharacteristics();
                        break;
                    }
                }

            }
        }

        [When(@"Take info about car")]
        public void WhenTakeInfoAboutCar()
        {
            trimComparisonPage = new TrimComparisonPage();
            carActual.Add(trimComparisonPage.GetConfigurationCar());
        }

        [When(@"Take info about engine and transmission")]
        public void WhenTakeInfoAboutEngineAndTransmission()
        {
            engineAndTransmissionExpected.Add(trimComparisonPage.SaveCharacteristicsCar());
        }
    
        [Then(@"Is right charachteristics car (.*)")]
        public void ThenIsRightCharachteristicsCar(int index)
        {
            Assert.AreEqual(carExpected[index], carActual[index], "Cars don't match");
        }


        [When(@"Navigate to Compare cars")]
        public void WhenNavigateToCompareCars()
        {
            trimComparisonPage.NavigateToResearchPage();
            researchPage = new ResearchPage();
            researchPage.NavigateToCompareCarsPage();
        }

        [When(@"Add first car for compare")]
        public void WhenAddFirstCarForCompare()
        {
            compareCarsPage = new CompareCarsPage();
            compareCarsPage.SelectFirstCar(carActual[0]);
        }

        [When(@"Add second car for compare")]
        public void WhenAddSecondCarForCompare()
        {
            compareCarsPage.AddCar(carActual[1]);
        }

        [Then(@"Is right are selected cars charachteristics")]
        public void ThenIsRightAreSelectedCarsCharachteristics()
        {
            engineAndTransmissionActual.Add(compareCarsPage.GetCharacteristicsFirstCar());
            engineAndTransmissionActual.Add(compareCarsPage.GetCharacteristicsSecondCar());
            Assert.AreEqual(engineAndTransmissionExpected[0], engineAndTransmissionActual[0],"1 not match");               
            Assert.AreEqual(engineAndTransmissionExpected[1], engineAndTransmissionActual[1],"2 not match");
        }
    }
}
