using OpenQA.Selenium;
using Framework.Elements;
using NUnit.Framework;

namespace SmartCars.PageObjects
{
    public class HomePage : CarsBaseForm
    {      
        private readonly Button _btnHomePage = new Button(By.XPath("//div/section/a[contains(text(),'Get Started')]"), "Button HomePage");

        public HomePage() {
            Assert.True(IsTruePage(_btnHomePage), "This is not HomePage");
        }
    }
}