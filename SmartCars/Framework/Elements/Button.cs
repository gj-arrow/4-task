using OpenQA.Selenium;

namespace Framework.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base (locator)
        {
            WaitUntilDisplayed();
        }

        public Button(By locator, string name) : base(locator, name)
        {
            WaitUntilDisplayed();
        }
    }
}
