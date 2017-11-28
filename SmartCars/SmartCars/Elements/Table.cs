using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using Framework.Elements;
using OpenQA.Selenium;

namespace SmartCars.Elements
{
    public class Table : BaseElement
    {
        public Table(By locator) : base(locator)
        {
        }

        public Table(By locator, string name) : base(locator, name)
        {
        }

        public string GetInnerHtml()
        {
            WaitUntilDisplayed();
            var locatorToDiscountGames = Element.GetAttribute("innerHTML");
            return locatorToDiscountGames;
        }
    }
}