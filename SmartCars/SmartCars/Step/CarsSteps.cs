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
        private readonly List<Car> _carsExpected = new List<Car>();
        private readonly List<Car> _carsActual = new List<Car>();
        private TrimComparisonPage _trimComparisonPage;
        private ResearchPage _researchPage;
        private CarInfoPage _carInfoPage;
        private CompareCarsPage _compareCarsPage;
        private readonly CarsBaseForm _carsBaseForm = new CarsBaseForm();

        [Before()]
        public void Before()
        {
            _browser = Browser.GetInstance();          
        }

        [After()]
        public void After()
        {
            _browser.CloseDriver();
        }

        [Given(@"User navigate to cars\.com - Main page")]
        public void GivenUserNavigateToCars_Com()
        {
            _browser.GoToUrl(Config.Url);
            var homePage = new HomePage();
        }
        
        [Given(@"Navigate to '(.*)' page")]
        public void GivenNavigateToPage(string menuItem)
        {
            _carsBaseForm.GetMainMenu().NavigateToMenuItem(menuItem);
        }
        
        [Given(@"Select random car")]
        public void GivenSelectRandomCar()
        {
            _researchPage = new ResearchPage();
            _researchPage.SelectRandomCar();
        }
        
        [Given(@"Navigate to Compare cars page")]
        public void GivenNavigateToCompareCarsPage()
        {
            GivenNavigateToPage("Research");
            _researchPage.NavigateToCompareCarsPage();
            _compareCarsPage = new CompareCarsPage();
        }
        
        [When(@"Save expected info about car")]
        public void WhenSaveExpectedInfoAboutCar()
        {
            _carsExpected.Add(_researchPage.GetCarInfo());
        }
        
        [When(@"Click Search button")]
        public void WhenClickSearchButton()
        {
            _researchPage.ClickSearchButton();
        }
        
        [When(@"Click Menu '(.*)'")]
        public void WhenClickMenu(string menuItem)
        {
            _carInfoPage = new CarInfoPage();
            if (_carInfoPage.IsButtonExists())
            {
                _carsBaseForm.GetCarInfoMenu().NavigateToMenuItem(menuItem);
            }
            else
            {
                try
                {
                    for (var i = 0; i < 6; i++)
                    {
                        _carsExpected.Remove(_carsExpected.Last());
                        GivenNavigateToPage("Research");
                        GivenSelectRandomCar();
                        _carsExpected.Add(_researchPage.GetCarInfo());
                        WhenClickSearchButton();
                        if (_carInfoPage.IsButtonExists())
                        {
                            _carsBaseForm.GetCarInfoMenu().NavigateToMenuItem(menuItem);
                            break;
                        }
                        if (i == 5)
                        {
                            var carNotFound = new Exception("The car wasn't found.");
                            throw carNotFound;
                        }
                    }
                }
                catch (Exception e)
                {
                    var carNotFound = new Exception("The car wasn't found." + e.Message);
                    throw carNotFound;
                }
            }
        }
        
        [When(@"Click Trim comparison button")]
        public void WhenClickTrimComparisonButton()
        {
            _carInfoPage.NavigateToCarCharacteristics();
        }
        
        [When(@"Save actual info about car")]
        public void WhenSaveActualInfoAboutCar()
        {
            _trimComparisonPage = new TrimComparisonPage();
            _carsActual.Add(_trimComparisonPage.GetConfigurationCar());
        }
        
        [When(@"Select car (.*)")]
        public void WhenSelectCar(int numberCar)
        {
            _compareCarsPage.SelectCar(_carsActual[numberCar]);           
        }
        
        [When(@"Add car (.*) for compare")]
        public void WhenAddCarForCompare(int numberCar)
        {
            _compareCarsPage.AddSelectedCarToCompare(numberCar);
        }
        
        [When(@"Take actual car (.*)")]
        public void WhenTakeActualCar(int numberCar)
        {
            _carsActual[numberCar] = _compareCarsPage.GetCharacteristicstCar(numberCar);
        }
        
        [When(@"Click button Add another car")]
        public void WhenClickButtonAddAnotherCar()
        {
            _compareCarsPage.ClickButtonAddCar();
        }       
        
        [Then(@"Save expected characteristics car (.*)")]
        public void ThenSaveExpectedCharacteristicsCar(int numberCar)
        {
            _carsExpected[numberCar].CharacteristicsCar = _trimComparisonPage.SaveCharacteristicsCar();
        }
        
        [Then(@"Expected and actual car (.*) must match")]
        public void ThenExpectedAndActualCarMustMatch(int numberCar)
        {
            Assert.AreEqual(_carsExpected[numberCar], _carsActual[numberCar], "Expected and actual car #" + numberCar + " not match");
        }
    }
}